using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Common;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IMiscMethodsAccess
{
    /// <summary>
    ///     List of available localization cultures
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Get the common settings used by the Bungie.Net environment.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Get the user-specific system overrides that should be respected alongside common systems.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
    /// </summary>
    /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(
        bool includestreaming = false,
        CancellationToken cancellationToken = default);
}