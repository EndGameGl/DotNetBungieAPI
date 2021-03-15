using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI
{
    public static class GroupV2Methods
    {
        private static IHttpClientInstance _httpClient;
        static GroupV2Methods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
    }
}
