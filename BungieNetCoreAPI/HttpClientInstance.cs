using NetBungieApi.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieApi
{
    internal class HttpClientInstance : IHttpClientInstance
    {
        private static HttpClient _httpClient;

        internal HttpClientInstance()
        {
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
            //Logger.Log($"Getting data from {query}", LogType.Debug);
            return await _httpClient.GetAsync(query);
        }

        public async Task<HttpResponseMessage> Send(HttpMethod method, Uri requestUri, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage() { Method = method, RequestUri = requestUri };
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return await _httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> Send(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }
    }
}
