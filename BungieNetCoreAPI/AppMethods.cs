using NetBungieAPI.Bungie.Applications;
using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public static class AppMethods
    {
        private static IHttpClientInstance _httpClient;
        static AppMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }
        
        public static async Task<BungieResponse<BungieApplication[]>> GetBungieApplications()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieApplication[]>>("/App/FirstParty/");
        }
        public static async Task<BungieResponse<ApiUsage>> GetApplicationApiUsage(int applicationId)
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<ApiUsage>>($"/App/ApiUsage/{applicationId}/");
        }

    }
}
