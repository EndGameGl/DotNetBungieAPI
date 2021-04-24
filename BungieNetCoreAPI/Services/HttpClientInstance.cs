using NetBungieAPI.Logging;
using NetBungieAPI.Authrorization;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private const string _authorizationEndpoint = "https://www.bungie.net/en/oauth/authorize";
        private const string _authorizationTokenEndpoint = "https://www.bungie.net/platform/app/oauth/token/";
        private const string _platformEndpoint = "https://www.bungie.net/Platform";
        private const string _cdnEndpoint = "https://www.bungie.net";
        private const string _statsEndpoint = "https://www.stats.bungie.net";

        private readonly HttpClient _httpClient;

        internal HttpClientInstance(ILogger logger, IConfigurationService configuration,
            IJsonSerializationHelper serializationHelper)
        {
            _logger = logger;
            _config = configuration;
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(6000)
            };
            _serializationHelper = serializationHelper;
        }

        public void AddAcceptHeader(string headerValue)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue));
        }

        public void AddHeader(string header, string headerValue)
        {
            _httpClient.DefaultRequestHeaders.Add(header, headerValue);
        }

        public async Task<AuthorizationTokenData> GetAuthorizationToken(string code, string authValue)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_authorizationTokenEndpoint),
                Content = new StringContent($"grant_type=authorization_code&code={code}")
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", authValue);
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
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_authorizationTokenEndpoint),
                Content = new StringContent($"grant_type=refresh_token&code={oldToken.RefreshToken}")
            };
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue(oldToken.TokenType, oldToken.AccessToken);
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
            var link = $"{_authorizationEndpoint}?client_id={clientId}&response_type=code&state={state}";
            return link;
        }

        /// <summary>
        /// Downloads json data from CDN
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async ValueTask<string> DownloadJSONDataFromCDNAsync(string url)
        {
            var response = await _httpClient.GetAsync(_cdnEndpoint + url);
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
            var response = await _httpClient.GetAsync(_cdnEndpoint + url);
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
            var response = await _httpClient.GetAsync(_cdnEndpoint + url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var memStream = new MemoryStream())
                    {
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
                }
            }

            return image;
        }

        private HttpRequestMessage CreateGetMessage(string uri, string authToken = null)
        {
            var requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get
            };

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.TryAddWithoutValidation("X-API-Key", _config.Settings.IdentificationSettings.ApiKey);
            requestMessage.Headers.TryAddWithoutValidation("cache-control", "no-cache");
            if (!string.IsNullOrEmpty(authToken))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

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
            if (content is not null)
            {
                content.Position = 0;
                requestMessage.Content = new StreamContent(content);
            }

            return requestMessage;
        }

        public async Task DownloadFileStreamFromCDNAsync(string query, string savePath)
        {
            using var response =
                await _httpClient.GetAsync(_cdnEndpoint + query, HttpCompletionOption.ResponseHeadersRead);
            await using var stream = await response.Content.ReadAsStreamAsync();
            await using Stream streamToWriteTo = File.Open(savePath, FileMode.Create);
            await stream.CopyToAsync(streamToWriteTo);
        }

        public async ValueTask<BungieResponse<T>> GetFromBungieNetPlatform<T>(string query, CancellationToken token,
            string authToken = null)
        {
            var finalQuery = StringBuilderPool
                .GetBuilder(token)
                .Append(_platformEndpoint)
                .Append(query)
                .Build();
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreateGetMessage(finalQuery, authToken);
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
                .Append(_platformEndpoint)
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
                .Append(_statsEndpoint)
                .Append(query)
                .Build();
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreateGetMessage(finalQuery, authToken);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            await using var stream = await response.Content.ReadAsStreamAsync(token);
            var bungieResponse = await _serializationHelper.DeserializeAsync<BungieResponse<T>>(stream);
            return bungieResponse;
        }
    }
}