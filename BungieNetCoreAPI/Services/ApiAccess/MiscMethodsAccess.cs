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

        /// <summary>
        /// List of available localization cultures
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<string, string>>("/GetAvailableLocales", token);
        }
        /// <summary>
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<CoreSettingsConfiguration>("/Settings", token);
        }
        /// <summary>
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<Dictionary<string, CoreSystem>>("/UserSystemOverrides", token);
        }
        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(CancellationToken token = default)
        {
            return await _httpClient.GetFromBungieNetPlatform<GlobalAlert[]>("/GlobalAlerts", token);
        }
    }
}