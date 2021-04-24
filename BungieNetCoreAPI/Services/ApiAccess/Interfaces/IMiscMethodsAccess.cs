using NetBungieAPI.Models;
using NetBungieAPI.Models.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IMiscMethodsAccess
    {
        /// <summary>
        /// List of available localization cultures
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(CancellationToken token = default);

        /// <summary>
        /// Get the common settings used by the Bungie.Net environment.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(CancellationToken token = default);

        /// <summary>
        /// Get the user-specific system overrides that should be respected alongside common systems.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(
            CancellationToken token = default);

        /// <summary>
        /// Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
        /// </summary>
        /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(bool includestreaming = false,
            CancellationToken token = default);
    }
}