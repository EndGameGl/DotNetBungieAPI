using NetBungieAPI.Models;
using NetBungieAPI.Models.Common;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess
{
    public class MiscMethodsAccess : IMiscMethodsAccess
    {
        private IHttpClientInstance _httpClient;

        internal MiscMethodsAccess(IHttpClientInstance httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<string, string>>("/GetAvailableLocales/",
                token);
        }
        
        public async ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<CoreSettingsConfiguration>("/Settings/", token);
        }
        
        public async ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(
            CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<string, CoreSystem>>("/UserSystemOverrides/",
                token);
        }

        public async ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(
            bool includestreaming = false,
            CancellationToken token = default)
        {
            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/GlobalAlerts/")
                .AddQueryParam("includestreaming", includestreaming.ToString())
                .Build();
            return await _httpClient.GetFromBungieNetPlatform<GlobalAlert[]>(url, token);
        }
    }
}