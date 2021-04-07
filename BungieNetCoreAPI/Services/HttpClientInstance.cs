using NetBungieAPI.Logging;
using NetBungieAPI.Authrorization;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NetBungieAPI.Services.Interfaces;
using System.Threading;
using NetBungieAPI.Serialization;

namespace NetBungieAPI.Services
{
    internal class HttpClientInstance : IHttpClientInstance
    {
        private readonly System.Text.Json.JsonSerializerOptions _jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions()
        {
            Converters = 
            { 
                new ReadOnlyCollectionConverterFactory(),
                new DefinitionHashPointerConverterFactory(),
                new ReadOnlyDictionaryConverterFactory()
            }
        };
        private readonly ILogger _logger;
        private readonly IConfigurationService _config;

        private readonly Uri _authorizationEndpoint = new Uri("https://www.bungie.net/en/oauth/authorize");
        private readonly Uri _authorizationTokenEndpoint = new Uri("https://www.bungie.net/platform/app/oauth/token/");
        private readonly Uri _platformEndpoint = new Uri("https://www.bungie.net/Platform");
        private readonly Uri _cdnEndpoint = new Uri("https://www.bungie.net");
        private readonly Uri _statsEndpoint = new Uri("https://www.stats.bungie.net");

        private readonly HttpClient _httpClient;
        internal HttpClientInstance(ILogger logger, IConfigurationService configuration)
        {
            _logger = logger;
            _config = configuration;
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(6000)              
            };
        }

        public void AddAcceptHeader(string headerValue)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue));
        }
        public void AddHeader(string header, string headerValue)
        {
            _httpClient.DefaultRequestHeaders.Add(header, headerValue);
        }
        public void RemoveHeader(string header)
        {
            _httpClient.DefaultRequestHeaders.Remove(header);
        }
        public async Task<HttpResponseMessage> Get(string query)
        {
            return await _httpClient.GetAsync(query);
        }

        public async Task<HttpResponseMessage> PostToPlatform(string query, string content)
        {
            var url = $"{_platformEndpoint}{query}";
            _logger.Log($"Calling platform API: {url}", LogType.Debug);
            return await _httpClient.PostAsync(url, new StringContent(content));
        }
        public async Task<HttpResponseMessage> GetFromPlatform(string query)
        {
            var url = $"{_platformEndpoint}{query}";
            _logger.Log($"Calling platform API: {url}", LogType.Debug);
            return await _httpClient.GetAsync(url);
        }
        public async Task<HttpResponseMessage> GetFromStatsPlatform(string query)
        {
            return await _httpClient.GetAsync($"{_statsEndpoint}{query}");
        }
        public async Task<AuthorizationTokenData> GetAuthorizationToken(string code, string authValue)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = _authorizationTokenEndpoint,
                Content = new StringContent($"grant_type=authorization_code&code={code}")
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", authValue);
            requestMessage.Content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<AuthorizationTokenData>(await response.Content.ReadAsStringAsync());

                return token;
            }

            throw new Exception("Failed to fetch token.");
        }
        public async Task<AuthorizationTokenData> RenewAuthorizationToken(AuthorizationTokenData oldToken)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = _authorizationTokenEndpoint,
                Content = new StringContent($"grant_type=refresh_token&code={oldToken.RefreshToken}")
            };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(oldToken.TokenType, oldToken.AccessToken);
            requestMessage.Content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<AuthorizationTokenData>(await response.Content.ReadAsStringAsync());
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
        public async Task<string> DownloadJSONDataFromCDNAsync(string url)
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
        public async Task<Image> DownloadImageFromCDNAsync(string url)
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
                    }
                }
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
        public async Task<Image> DownloadImageFromCDNAndSaveAsync(string url, string folderPath, string filename, ImageFormat format)
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

                        var targetDirectory = $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\";
                        var targetFileName = $"{(string.IsNullOrWhiteSpace(folderPath) ? Environment.CurrentDirectory : folderPath)}\\{filename}.{format.ToString().ToLower()}";
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
        public async Task<T> GetFromStatsPlatfromAndDeserialize<T>(string query)
        {
            var response = await GetFromStatsPlatform(query);
            return await response.ReadObjectFromHttpResponseMessage<T>();
        }
        public async Task<T> PostToPlatformAndDeserialize<T>(string query, string data)
        {
            var response = await PostToPlatform(query, data);
            return await response.ReadObjectFromHttpResponseMessage<T>();
        }


        public async Task<T> GetFromPlatfromAndDeserialize<T>(string query, string authToken = null)
        {          
            var response = await GetFromPlatform(query);
            return await response.ReadObjectFromHttpResponseMessage<T>();
        }


        private HttpRequestMessage CreateGetMessage(string uri, string authToken = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get               
            };

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.TryAddWithoutValidation("X-API-Key", _config.Settings.ApiKey);
            requestMessage.Headers.TryAddWithoutValidation("cache-control", "no-cache");
            //requestMessage.Headers.UserAgent.ParseAdd("PostmanRuntime/7.26.10");
            if (!string.IsNullOrEmpty(authToken))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            return requestMessage;
        }
        private HttpRequestMessage CreatePostMessage(string uri, string authToken = null, string content = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Post
            };

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.TryAddWithoutValidation("X-API-Key", _config.Settings.ApiKey);

            if (!string.IsNullOrEmpty(authToken))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            if (!string.IsNullOrEmpty(content))
                requestMessage.Content = new StringContent(content);
            return requestMessage;
        }
        public async Task DownloadFileStreamFromCDNAsync(string query, string savePath)
        {
            using var response = await _httpClient.GetAsync(_cdnEndpoint + query, HttpCompletionOption.ResponseHeadersRead);
            using var stream = await response.Content.ReadAsStreamAsync();
            using Stream streamToWriteTo = File.Open(savePath, FileMode.Create);
            await stream.CopyToAsync(streamToWriteTo);
        }
        public async ValueTask<BungieResponse<T>> GetFromBungieNetPlatform<T>(string query, CancellationToken token, string authToken = null)
        {
            var finalQuery = _platformEndpoint + query;
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreateGetMessage(finalQuery, authToken);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            using var stream = await response.Content.ReadAsStreamAsync();
            var bungieResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<BungieResponse<T>>(stream, _jsonSerializerOptions, token);
            return bungieResponse;
        }
        public async ValueTask<BungieResponse<T>> PostToBungieNetPlatform<T>(string query, CancellationToken token, string authToken = null)
        {
            var finalQuery = StringBuilderPool.GetBuilder().Append(_platformEndpoint.ToString()).Append(query).ToString();
            _logger.Log($"Calling api: {finalQuery}", LogType.Debug);
            var request = CreatePostMessage(finalQuery, authToken);
            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token);
            using var stream = await response.Content.ReadAsStreamAsync();
            var bungieResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<BungieResponse<T>>(stream, _jsonSerializerOptions, token);
            return bungieResponse;
        }
    }
}
