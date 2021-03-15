﻿using NetBungieAPI.Bungie;
using NetBungieAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetBungieAPI
{
    public static class MiscMethods
    {
        private static IHttpClientInstance _httpClient;
        static MiscMethods()
        {
            _httpClient = StaticUnityContainer.GetHTTPClient();
        }

        /// <summary>
        /// List of available localization cultures
        /// </summary>
        /// <returns></returns>
        public static async Task<BungieResponse<Dictionary<string, string>>> GetAvailableLocales()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<Dictionary<string, string>>>("/GetAvailableLocales");
        }
        /// <summary>
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        /// <returns></returns>
        public static async Task<BungieResponse<BungieNetSettings>> GetCommonSettings()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<BungieNetSettings>>("/Settings");
        }
        /// <summary>
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        /// <returns></returns>
        public static async Task<BungieResponse<Dictionary<string, BungieSystemSetting>>> GetUserSystemOverrides()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<Dictionary<string, BungieSystemSetting>>>("/UserSystemOverrides");
        }
        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <returns></returns>
        public static async Task<BungieResponse<GlobalAlert[]>> GetGlobalAlerts()
        {
            return await _httpClient.GetFromPlatfromAndDeserialize<BungieResponse<GlobalAlert[]>>("/GlobalAlerts");
        }
    }
}