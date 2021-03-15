using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public static class ForumMethods
    {
        private static IHttpClientInstance _httpClient;
        static ForumMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
    }
}
