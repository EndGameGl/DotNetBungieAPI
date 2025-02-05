using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.RateLimiting;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultDotNetBungieApiHttpClient : IDotNetBungieApiHttpClient
{
    private const string ApiKeyHeader = "X-API-Key";

    private const string AuthorizationEndpoint = "https://www.bungie.net/en/oauth/authorize";
    private const string AuthorizationTokenEndpoint =
        "https://www.bungie.net/platform/app/oauth/token/";
    private const string PlatformEndpoint = "https://www.bungie.net/Platform";
    private const string CdnEndpoint = "https://www.bungie.net";
    private const string StatsEndpoint = "https://stats.bungie.net/Platform";
    private readonly IBungieClientConfiguration _configuration;

    private readonly HttpClient _httpClient;

    private readonly MediaTypeWithQualityHeaderValue _jsonHeaderValue = new("application/json");

    private readonly ILogger<DefaultDotNetBungieApiHttpClient> _logger;
    private readonly IBungieNetJsonSerializer _serializer;
    private readonly ApiRateLimiter _apiRateLimiter;

    public DefaultDotNetBungieApiHttpClient(
        IBungieClientConfiguration configuration,
        DotNetBungieApiHttpClientConfiguration httpClientConfiguration,
        ILogger<DefaultDotNetBungieApiHttpClient> logger,
        IBungieNetJsonSerializer serializer
    )
    {
        _configuration = configuration;
        _logger = logger;
        _serializer = serializer;

        if (httpClientConfiguration._overrideHttpClient is null)
        {
            var httpHandler = new SocketsHttpHandler();
            if (httpClientConfiguration.ConfigureHttpHandler is not null)
            {
                httpClientConfiguration.ConfigureHttpHandler(httpHandler);
            }
            _httpClient = new HttpClient(httpHandler);
            if (httpClientConfiguration.ConfigureHttpClient is not null)
            {
                httpClientConfiguration.ConfigureHttpClient(_httpClient);
            }
        }
        else
        {
            _httpClient = httpClientConfiguration._overrideHttpClient;
        }

        _httpClient.DefaultRequestHeaders.Accept.Add(_jsonHeaderValue);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "DotNetBungieApi Client");

        _apiRateLimiter = new ApiRateLimiter(
            _logger,
            httpClientConfiguration.RateLimitPerInterval,
            httpClientConfiguration.RateLimitInterval,
            httpClientConfiguration.MaxRequestsPerSecond,
            httpClientConfiguration.MaxConcurrentRequestsAtOnce
        );
    }

    public async Task<AuthorizationTokenData> GetAuthorizationToken(string code)
    {
        var encodedContentPairs = new List<KeyValuePair<string, string>>
        {
            new("grant_type", "authorization_code"),
            new("code", code),
            new("client_id", _configuration.ClientId.ToString())
        };

        if (!string.IsNullOrEmpty(_configuration.ClientSecret))
            encodedContentPairs.Add(
                new KeyValuePair<string, string>("client_secret", _configuration.ClientSecret)
            );

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(AuthorizationTokenEndpoint),
            Content = new FormUrlEncodedContent(encodedContentPairs)
        };

        requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader, _configuration.ApiKey);
        requestMessage.Content.Headers.ContentType!.MediaType = "application/x-www-form-urlencoded";
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await SendAsyncInternal(requestMessage);

        if (response.IsSuccessStatusCode)
        {
            var responseContentStream = await response.Content.ReadAsStreamAsync();
            return await _serializer.DeserializeAsync<AuthorizationTokenData>(
                responseContentStream
            );
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var parsedResponse = _serializer.Deserialize<AuthorizationResponseError>(responseBody);
        throw new BungieNetAuthorizationErrorException(parsedResponse, responseBody);
    }

    public async Task<AuthorizationTokenData> RenewAuthorizationToken(
        AuthorizationTokenData oldToken
    )
    {
        if (oldToken.DidRefreshExpired)
            throw new ReauthRequiredException(oldToken.MembershipId);

        var encodedContentPairs = new List<KeyValuePair<string, string>>
        {
            new("grant_type", "refresh_token"),
            new("refresh_token", oldToken.RefreshToken),
            new("client_id", _configuration.ClientId!.ToString())
        };

        if (!string.IsNullOrEmpty(_configuration.ClientSecret))
            encodedContentPairs.Add(
                new KeyValuePair<string, string>("client_secret", _configuration.ClientSecret)
            );

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(AuthorizationTokenEndpoint),
            Content = new FormUrlEncodedContent(encodedContentPairs)
        };

        requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader, _configuration.ApiKey);
        requestMessage.Content.Headers.ContentType!.MediaType = "application/x-www-form-urlencoded";
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await SendAsyncInternal(requestMessage);

        if (response.IsSuccessStatusCode)
        {
            var responseContentStream = await response.Content.ReadAsStreamAsync();
            return await _serializer.DeserializeAsync<AuthorizationTokenData>(
                responseContentStream
            );
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var parsedResponse = _serializer.Deserialize<AuthorizationResponseError>(responseBody);
        throw new BungieNetAuthorizationErrorException(parsedResponse, responseBody);
    }

    public string GetAuthLink(int clientId, string state)
    {
        var link = $"{AuthorizationEndpoint}?client_id={clientId}&response_type=code&state={state}";
        return link;
    }

    /// <summary>
    ///     Downloads json data from CDN
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public async Task<string> DownloadJsonDataFromCdnAsync(string url)
    {
        var message = CreateGetMessage(CdnEndpoint + url, true);
        var response = await SendAsyncInternal(message);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        throw new Exception(response.ReasonPhrase);
    }

    public async Task DownloadFileFromCdnAsync(string query, string savePath)
    {
        using var response = await _httpClient.GetAsync(
            CdnEndpoint + query,
            HttpCompletionOption.ResponseHeadersRead
        );
        await using var stream = await response.Content.ReadAsStreamAsync();
        await using Stream streamToWriteTo = File.Open(savePath, FileMode.Create);
        await stream.CopyToAsync(streamToWriteTo);
    }

    public async Task<BungieResponse<T>> GetFromBungieNetPlatform<T>(
        string query,
        CancellationToken token,
        string? authToken = null
    )
    {
        var finalQuery = StringBuilderPool
            .GetBuilder(token)
            .Append(PlatformEndpoint)
            .Append(query)
            .Build();
        _logger.LogDebug("Calling api: {Method} {FinalQuery}", "GET", finalQuery);
        using var request = CreateGetMessage(finalQuery, false, authToken);
        using var response = await SendAsyncInternal(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            token
        );

        if (!response.IsSuccessStatusCode)
        {
            var responseContentType = response.Content.Headers.ContentType;
            if (responseContentType?.MediaType is "text/html")
            {
                var responseText = await response.Content.ReadAsStringAsync(token);
                throw new BungieHtmlResponseErrorException(response.StatusCode, responseText);
            }
        }

        await using var stream = await response.Content.ReadAsStreamAsync(token);
        var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
        return bungieResponse;
    }

    public async Task<BungieResponse<T>> PostToBungieNetPlatform<T>(
        string query,
        CancellationToken token,
        Stream? content = null,
        string? authToken = null
    )
    {
        var finalQuery = StringBuilderPool
            .GetBuilder(token)
            .Append(PlatformEndpoint)
            .Append(query)
            .Build();
        _logger.LogDebug("Calling api: {Method} {FinalQuery}", "POST", finalQuery);
        using var request = CreatePostMessage(finalQuery, authToken, content);
        using var response = await SendAsyncInternal(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            token
        );

        if (!response.IsSuccessStatusCode)
        {
            var responseContentType = response.Content.Headers.ContentType;
            if (responseContentType?.MediaType is "text/html")
            {
                var responseText = await response.Content.ReadAsStringAsync(token);
                throw new BungieHtmlResponseErrorException(response.StatusCode, responseText);
            }
        }

        await using var stream = await response.Content.ReadAsStreamAsync(token);
        var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
        return bungieResponse;
    }

    public async Task<BungieResponse<T>> GetFromBungieNetStatsPlatform<T>(
        string query,
        CancellationToken token,
        string? authToken = null
    )
    {
        var finalQuery = StringBuilderPool
            .GetBuilder(token)
            .Append(StatsEndpoint)
            .Append(query)
            .Build();

        _logger.LogDebug("Calling api: {Method} {FinalQuery}", "GET", finalQuery);
        using var request = CreateGetMessage(finalQuery, false, authToken);
        using var response = await SendAsyncInternal(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            token
        );

        if (!response.IsSuccessStatusCode)
        {
            var responseContentType = response.Content.Headers.ContentType;
            if (responseContentType?.MediaType is "text/html")
            {
                var responseText = await response.Content.ReadAsStringAsync(token);
                throw new BungieHtmlResponseErrorException(response.StatusCode, responseText);
            }
        }

        await using var stream = await response.Content.ReadAsStreamAsync(token);
        var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
        return bungieResponse;
    }

    public async Task<(Stream ContentStream, long? TotalLength)> GetStreamFromWebSourceAsync(
        string path
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Get, CdnEndpoint + path);
        var response = await _httpClient.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead
        );
        return (await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentLength);
    }

    private async Task<HttpResponseMessage> SendAsyncInternal(HttpRequestMessage requestMessage)
    {
        return await _apiRateLimiter.WaitAndRunAsync(
            async (ct) => await _httpClient.SendAsync(requestMessage, ct),
            default
        );
    }

    private async Task<HttpResponseMessage> SendAsyncInternal(
        HttpRequestMessage requestMessage,
        HttpCompletionOption httpCompletionOption,
        CancellationToken cancellationToken
    )
    {
        return await _apiRateLimiter.WaitAndRunAsync(
            async (ct) =>
            {
                var start = Stopwatch.GetTimestamp();
                var resp = await _httpClient.SendAsync(requestMessage, httpCompletionOption, ct);
                var end = Stopwatch.GetTimestamp();
                var elapsedTime = (double)(end - start) / Stopwatch.Frequency;
                _logger.LogDebug("Executed request in {Time}s", elapsedTime);
                return resp;
            },
            cancellationToken
        );
    }

    private HttpRequestMessage CreateGetMessage(
        string uri,
        bool omitApiKey = false,
        string? authToken = null
    )
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(uri),
            Method = HttpMethod.Get
        };

        requestMessage.Headers.Accept.Add(_jsonHeaderValue);
        if (omitApiKey == false)
        {
            requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader, _configuration.ApiKey);
        }
        if (!string.IsNullOrEmpty(authToken))
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                authToken
            );
        }
        return requestMessage;
    }

    private HttpRequestMessage CreatePostMessage(
        string uri,
        string? authToken = null,
        Stream? content = null
    )
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(uri),
            Method = HttpMethod.Post
        };

        requestMessage.Headers.Accept.Add(_jsonHeaderValue);
        requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader, _configuration.ApiKey);

        if (!string.IsNullOrEmpty(authToken))
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                authToken
            );
        }

        if (content is null)
            return requestMessage;
        content.Position = 0;
        requestMessage.Content = new StreamContent(content);

        return requestMessage;
    }
}
