using NetBungieAPI.Logging;
using NetBungieAPI.Authorization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NetBungieAPI.Services.Interfaces;
using System.Threading;
using NetBungieAPI.Models;

namespace NetBungieAPI.Services
{
    internal class HttpClientInstance : IHttpClientInstance
    {
        private readonly MediaTypeWithQualityHeaderValue _jsonHeaderValue =
            new MediaTypeWithQualityHeaderValue("application/json");

        private readonly ILogger _logger;
        private readonly IConfigurationService _config;
        private readonly IJsonSerializationHelper _serializationHelper;

        private const string AuthorizationEndpoint = "https://www.bungie.net/en/oauth/authorize";
        private const string AuthorizationTokenEndpoint = "https://www.bungie.net/platform/app/oauth/token/";
        private const string PlatformEndpoint = "https://www.bungie.net/Platform";
        private const string CdnEndpoint = "https://www.bungie.net";
        private const string StatsEndpoint = "https://stats.bungie.net/Platform";

        private readonly HttpClient _httpClient;

        internal HttpClientInstance(ILogger logger, IConfigurationService configuration,
            IJsonSerializationHelper serializationHelper)
        {
            _logger = logger;
            _config = configuration;
            _httpClient = new HttpClient(new HttpClientHandler()
            {
                CookieContainer = new CookieContainer(),
                UseCookies = true
            })
            {
                Timeout = TimeSpan.FromSeconds(6000)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "NetBungieApi Client");
            _serializationHelper = serializationHelper;
        }

        public async Task<AuthorizationTokenData> GetAuthorizationToken(string code)
        {
            var encodedContentPairs = new List<KeyValuePair<string?, string?>>
            {
                new("grant_type", "authorization_code"),
                new("code", code),
                new("client_id", _config.Settings.IdentificationSettings.ClientId.ToString())
            };

            if (!string.IsNullOrEmpty(_config.Settings.IdentificationSettings.ClientSecret))
                encodedContentPairs.Add(new KeyValuePair<string?, string?>(
                    "client_secret",
                    _config.Settings.IdentificationSettings.ClientSecret));

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(AuthorizationTokenEndpoint),
                Content = new FormUrlEncodedContent(encodedContentPairs)
            };

            requestMessage.Headers.TryAddWithoutValidation("X-API-Key",
                _config.Settings.IdentificationSettings.ApiKey);
            requestMessage.Content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch token.");
            var token = await _serializationHelper.DeserializeAsync<AuthorizationTokenData>(
                await response.Content.ReadAsStreamAsync());

            return token;
        }

        public async Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken)
        {
            var encodedContentPairs = new List<KeyValuePair<string?, string?>>
            {
                new("grant_type", "refresh_token"),
                new("refresh_token", oldToken.RefreshToken),
                new("client_id", _config.Settings.IdentificationSettings.ClientId.ToString())
            };
            
            if (!string.IsNullOrEmpty(_config.Settings.IdentificationSettings.ClientSecret))
                encodedContentPairs.Add(new KeyValuePair<string?, string?>(
                    "client_secret",
                    _config.Settings.IdentificationSettings.ClientSecret));
            
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(AuthorizationTokenEndpoint),
                Content = new FormUrlEncodedContent(encodedContentPairs)
            };
            
            requestMessage.Headers.TryAddWithoutValidation("X-API-Key",
                _config.Settings.IdentificationSettings.ApiKey);
            
            requestMessage.Content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await _serializationHelper.DeserializeAsync<AuthorizationTokenData>(
                    await response.Content.ReadAsStreamAsync());
            }

            throw new Exception("Failed to fetch token.");
        }

        public string GetAuthLink(int clientId, string state)
        {
            var link = $"{AuthorizationEndpoint}?client_id={clientId}&response_type=code&state={state}";
            return link;
        }

        /// <summary>
        /// Downloads json data from CDN
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async ValueTask<string> DownloadJSONDataFromCDNAsync(string url)
        {
            var message = CreateGetMessage(CdnEndpoint + url, true);
            var response = await _httpClient.SendAsync(message);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            else
                throw new Exception(response.ReasonPhrase);
        }

        /// <summary>
        /// Downloads image from CDN (WARNING: It can't be saved into file later)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async ValueTask<Image> DownloadImageFromCDNAsync(string url)
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
        /// Downloads an image from give url and saves to disk
        /// </summary>
        /// <param name="url"></param>
        /// <param name="folderPath"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public async Task<Image> DownloadImageFromCDNAndSaveAsync(string url, string folderPath, string filename,
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
                        throw new Exception("This file already exists.");
                }
                else
                    throw new Exception("Directory doesn't exist.");
            }

            return image;
        }

        private HttpRequestMessage CreateGetMessage(string uri, bool omitApiKey = false, string authToken = null)
        {
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get
            };

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (omitApiKey == false)
                requestMessage.Headers.TryAddWithoutValidation("X-API-Key",
                    _config.Settings.IdentificationSettings.ApiKey);
            if (!string.IsNullOrEmpty(authToken))
                requestMessage.Headers.Add("Authorization", $"Bearer {authToken}");
            return requestMessage;
        }

        private HttpRequestMessage CreatePostMessage(string uri, string authToken = null, Stream content = null)
        {
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Post
            };

            requestMessage.Headers.Accept.Add(_jsonHeaderValue);
            requestMessage.Headers.TryAddWithoutValidation("X-API-Key", _config.Settings.IdentificationSettings.ApiKey);

            if (!string.IsNullOrEmpty(authToken))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            if (content is null)
                return requestMessage;
            content.Position = 0;
            requestMessage.Content = new StreamContent(content);

            return requestMessage;
        }

        public async Task DownloadFileStreamFromCDNAsync(string query, string savePath)
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
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreateGetMessage(finalQuery, false, authToken);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            await using var stream = await response.Content.ReadAsStreamAsync(token);
            var bungieResponse = await _serializationHelper.DeserializeAsync<BungieResponse<T>>(stream);
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
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreatePostMessage(finalQuery, authToken, content);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            await using var stream = await response.Content.ReadAsStreamAsync(token);
            var bungieResponse = await _serializationHelper.DeserializeAsync<BungieResponse<T>>(stream);
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
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreateGetMessage(finalQuery, false, authToken);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            await using var stream = await response.Content.ReadAsStreamAsync(token);
            var bungieResponse = await _serializationHelper.DeserializeAsync<BungieResponse<T>>(stream);
            return bungieResponse;
        }
    }
}