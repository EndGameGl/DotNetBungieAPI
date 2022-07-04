using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using ComposableAsync;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Implementations.ServiceConfigurations;
using Microsoft.Extensions.Logging;
using RateLimiter;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefaultDotNetBungieApiHttpClient : IDotNetBungieApiHttpClient
{
    private const string ApiKeyHeader = "X-API-Key";

    private const string AuthorizationEndpoint = "https://www.bungie.net/en/oauth/authorize";
    private const string AuthorizationTokenEndpoint = "https://www.bungie.net/platform/app/oauth/token/";
    private const string PlatformEndpoint = "https://www.bungie.net/Platform";
    private const string CdnEndpoint = "https://www.bungie.net";
    private const string StatsEndpoint = "https://stats.bungie.net/Platform";
    private readonly IBungieClientConfiguration _configuration;

    private readonly HttpClient _httpClient;

    private readonly MediaTypeWithQualityHeaderValue _jsonHeaderValue =
        new("application/json");

    private readonly ILogger<DefaultDotNetBungieApiHttpClient> _logger;
    private readonly TimeLimiter _rateTimeLimiter;
    private readonly IBungieNetJsonSerializer _serializer;

    public DefaultDotNetBungieApiHttpClient(
        IBungieClientConfiguration configuration,
        DotNetBungieApiHttpClientConfiguration httpClientConfiguration,
        ILogger<DefaultDotNetBungieApiHttpClient> logger,
        IBungieNetJsonSerializer serializer)
    {
        _configuration = configuration;
        _logger = logger;
        _serializer = serializer;
        _httpClient = httpClientConfiguration.HttpClient;
        _httpClient.DefaultRequestHeaders.Accept.Add(_jsonHeaderValue);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "DotNetBungieApi Client");

        _rateTimeLimiter = TimeLimiter.GetFromMaxCountByInterval(
            httpClientConfiguration.RatelimitPerInterval,
            httpClientConfiguration.RatelimitInterval);
    }

    public async ValueTask<AuthorizationTokenData> GetAuthorizationToken(string code)
    {
        var encodedContentPairs = new List<KeyValuePair<string, string>>
        {
            new("grant_type", "authorization_code"),
            new("code", code),
            new("client_id", _configuration.ClientId!.ToString())
        };

        if (!string.IsNullOrEmpty(_configuration.ClientSecret))
            encodedContentPairs.Add(new KeyValuePair<string, string>(
                "client_secret",
                _configuration.ClientSecret));

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(AuthorizationTokenEndpoint),
            Content = new FormUrlEncodedContent(encodedContentPairs)
        };

        requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader,
            _configuration.ApiKey);
        requestMessage.Content.Headers.ContentType!.MediaType = "application/x-www-form-urlencoded";
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await SendAsyncInternal(requestMessage).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Failed to fetch token.");
        var token = await _serializer.DeserializeAsync<AuthorizationTokenData>(
            await response.Content.ReadAsStreamAsync());

        return token;
    }

    public async ValueTask<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken)
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
            encodedContentPairs.Add(new KeyValuePair<string, string>(
                "client_secret",
                _configuration.ClientSecret));

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(AuthorizationTokenEndpoint),
            Content = new FormUrlEncodedContent(encodedContentPairs)
        };

        requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader,
            _configuration.ApiKey);

        requestMessage.Content.Headers.ContentType!.MediaType = "application/x-www-form-urlencoded";
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await SendAsyncInternal(requestMessage).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
            return await _serializer.DeserializeAsync<AuthorizationTokenData>(
                await response.Content.ReadAsStreamAsync()).ConfigureAwait(false);

        throw new Exception("Failed to fetch token.");
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
    public async ValueTask<string> DownloadJsonDataFromCdnAsync(string url)
    {
        var message = CreateGetMessage(CdnEndpoint + url, true);
        var response = await SendAsyncInternal(message);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        throw new Exception(response.ReasonPhrase);
    }

    public async Task DownloadFileStreamFromCdnAsync(string query, string savePath)
    {
        using var response =
            await _httpClient.GetAsync(CdnEndpoint + query, HttpCompletionOption.ResponseHeadersRead);
        await using var stream = await response.Content.ReadAsStreamAsync();
        await using Stream streamToWriteTo = File.Open(savePath, FileMode.Create);
        await stream.CopyToAsync(streamToWriteTo);
    }

    public async ValueTask<BungieResponse<T>> GetFromBungieNetPlatform<T>(string query, CancellationToken token,
        string authToken = null)
    {
        var finalQuery = StringBuilderPool
            .GetBuilder(token)
            .Append(PlatformEndpoint)
            .Append(query)
            .Build();
        _logger.LogDebug("Calling api: {FinalQuery}", finalQuery);
        var request = CreateGetMessage(finalQuery, false, authToken);
        var response = await SendAsyncInternal(request, HttpCompletionOption.ResponseHeadersRead, token);
        await using var stream = await response.Content.ReadAsStreamAsync(token);
        var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
        return bungieResponse;
    }

    public async ValueTask<BungieResponse<T>> PostToBungieNetPlatform<T>(string query, CancellationToken token,
        Stream content = null, string authToken = null)
    {
        var finalQuery = StringBuilderPool
            .GetBuilder(token)
            .Append(PlatformEndpoint)
            .Append(query)
            .Build();
        _logger.LogDebug("Calling api: {FinalQuery}", finalQuery);
        var request = CreatePostMessage(finalQuery, authToken, content);
        var response = await SendAsyncInternal(request, HttpCompletionOption.ResponseHeadersRead, token);
        await using var stream = await response.Content.ReadAsStreamAsync(token);
        var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
        return bungieResponse;
    }

    public async ValueTask<BungieResponse<T>> GetFromBungieNetStatsPlatform<T>(string query,
        CancellationToken token, string authToken = null)
    {
        var finalQuery = StringBuilderPool
            .GetBuilder(token)
            .Append(StatsEndpoint)
            .Append(query)
            .Build();
        _logger.LogDebug("Calling api: {FinalQuery}", finalQuery);
        var request = CreateGetMessage(finalQuery, false, authToken);
        var response = await SendAsyncInternal(request, HttpCompletionOption.ResponseHeadersRead, token);
        await using var stream = await response.Content.ReadAsStreamAsync(token);
        var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
        return bungieResponse;
    }

    public async ValueTask<(Stream ContentStream, long? TotalLength)> GetStreamFromWebSourceAsync(string path)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, CdnEndpoint + path);
        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        return (await response.Content.ReadAsStreamAsync(), response.Content.Headers.ContentLength);
    }

    private async Task<HttpResponseMessage> SendAsyncInternal(
        HttpRequestMessage requestMessage)
    {
        await _rateTimeLimiter;
        return await _httpClient.SendAsync(requestMessage);
    }

    private async Task<HttpResponseMessage> SendAsyncInternal(
        HttpRequestMessage requestMessage,
        HttpCompletionOption httpCompletionOption,
        CancellationToken cancellationToken)
    {
        await _rateTimeLimiter;
        var result = await _httpClient.SendAsync(requestMessage, httpCompletionOption, cancellationToken);
        return result;
    }

    private HttpRequestMessage CreateGetMessage(string uri, bool omitApiKey = false, string authToken = null)
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(uri),
            Method = HttpMethod.Get
        };

        requestMessage.Headers.Accept.Add(_jsonHeaderValue);
        if (omitApiKey == false)
            requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader,
                _configuration.ApiKey);
        if (!string.IsNullOrEmpty(authToken))
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        return requestMessage;
    }

    private HttpRequestMessage CreatePostMessage(string uri, string authToken = null, Stream content = null)
    {
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri(uri),
            Method = HttpMethod.Post
        };

        requestMessage.Headers.Accept.Add(_jsonHeaderValue);
        requestMessage.Headers.TryAddWithoutValidation(ApiKeyHeader, _configuration.ApiKey);

        if (!string.IsNullOrEmpty(authToken))
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        if (content is null)
            return requestMessage;
        content.Position = 0;
        requestMessage.Content = new StreamContent(content);

        return requestMessage;
    }
}