using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public static class CommunityContentMethods
    {
        private static IHttpClientInstance _httpClient;
        static CommunityContentMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
    }
}
