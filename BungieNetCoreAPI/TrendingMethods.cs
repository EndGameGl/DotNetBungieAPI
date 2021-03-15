using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public static class TrendingMethods
    {
        private static IHttpClientInstance _httpClient;
        static TrendingMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
    }
}
