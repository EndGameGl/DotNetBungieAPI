using BungieNetCoreAPI.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BungieNetCoreAPI
{
    internal static class HttpClientInstance
    {
        private static HttpClient _httpClient;

        internal static void Initialize()
        {
            _httpClient = new HttpClient()
            { 
                Timeout = TimeSpan.FromSeconds(6000)
            };
        }

        public static void AddAcceptHeader(string headerValue)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue));
        }
        public static void AddHeader(string header, string headerValue)
        {
            _httpClient.DefaultRequestHeaders.Add(header, headerValue);
        }
        public static void RemoveHeader(string header)
        {
            _httpClient.DefaultRequestHeaders.Remove(header);
        }
        public static async Task<HttpResponseMessage> Get(string query)
        {
            Logger.Log($"Getting data from {query}", LogType.Debug);
            return await _httpClient.GetAsync(query);
        }
    }
}
