using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public static class FireteamMethods
    {
        private static IHttpClientInstance _httpClient;
        static FireteamMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
    }
}
