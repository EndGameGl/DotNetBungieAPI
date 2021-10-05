using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Exceptions;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Services.Default.ServiceConfigurations;
using DotNetBungieAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Default
{
    internal sealed class DefaultDotNetBungieApiHttpClient : IDotNetBungieApiHttpClient
    {
        private readonly BungieClientConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IBungieNetJsonSerializer _serializer;
        
        private const string ApiKeyHeader = "X-API-Key";

        private const string AuthorizationEndpoint = "https://www.bungie.net/en/oauth/authorize";
        private const string AuthorizationTokenEndpoint = "https://www.bungie.net/platform/app/oauth/token/";
        private const string PlatformEndpoint = "https://www.bungie.net/Platform";
        private const string CdnEndpoint = "https://www.bungie.net";
        private const string StatsEndpoint = "https://stats.bungie.net/Platform";

        private readonly HttpClient _httpClient;

        private readonly MediaTypeWithQualityHeaderValue _jsonHeaderValue =
            new("application/json");

        public DefaultDotNetBungieApiHttpClient(
            BungieClientConfiguration configuration, 
            DotNetBungieApiHttpClientConfiguration httpClientConfiguration,
            ILogger logger,
            IBungieNetJsonSerializer serializer)
        {
            _configuration = configuration;
            _logger = logger;
            _serializer = serializer;
            _httpClient = httpClientConfiguration.HttpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(_jsonHeaderValue);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "NetBungieApi Client");
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
            var response = await _httpClient.SendAsync(requestMessage);

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

            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

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
            var response = await _httpClient.SendAsync(message);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            throw new Exception(response.ReasonPhrase);
        }

        /// <summary>
        ///     Downloads image from CDN (WARNING: It can't be saved into file later)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async ValueTask<Image> DownloadImageFromCdnAsync(string url)
        {
            Image image = null;
            var response = await _httpClient.GetAsync(CdnEndpoint + url);
            if (response.IsSuccessStatusCode)
            {
                await using var stream = await response.Content.ReadAsStreamAsync();
                await using var memStream = new MemoryStream();
                await stream.CopyToAsync(memStream);
                memStream.Position = 0;
                image = Image.FromStream(memStream);
            }

            return image;
        }

        /// <summary>
        ///     Downloads an image from give url and saves to disk
        /// </summary>
        /// <param name="url"></param>
        /// <param name="folderPath"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public async Task<Image> DownloadImageFromCdnAndSaveAsync(string url, string folderPath, string filename,
            ImageFormat format)
        {
            Image image = null;
            var response = await _httpClient.GetAsync(CdnEndpoint + url);
            if (response.IsSuccessStatusCode)
            {
                await using var stream = await response.Content.ReadAsStreamAsync();
                await using var memStream = new MemoryStream();
                await stream.CopyToAsync(memStream);
                memStream.Position = 0;
                image = Image.FromStream(memStream);

                var targetDirectory =
                    $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\";
                var targetFileName =
                    $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\{filename}.{format.ToString().ToLower()}";
                if (Directory.Exists(targetDirectory))
                {
                    if (!File.Exists(targetFileName))
                    {
                        image.Save(targetFileName, format);
                        image.Dispose();
                    }
                    else
                    {
                        throw new Exception("This file already exists.");
                    }
                }
                else
                {
                    throw new Exception("Directory doesn't exist.");
                }
            }

            return image;
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
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
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
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
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
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            await using var stream = await response.Content.ReadAsStreamAsync(token);
            var bungieResponse = await _serializer.DeserializeAsync<BungieResponse<T>>(stream);
            return bungieResponse;
        }

        public async ValueTask<Stream> GetStreamFromWebSourceAsync(string path)
        {
            var response = await _httpClient.GetAsync(
                CdnEndpoint + path,
                HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
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
}