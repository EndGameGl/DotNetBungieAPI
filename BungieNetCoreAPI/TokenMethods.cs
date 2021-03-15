using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public static class TokenMethods
    {
        private static IHttpClientInstance _httpClient;
        static TokenMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
    }
}
