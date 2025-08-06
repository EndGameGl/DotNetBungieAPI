using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IMiscApi
{
    Task<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Common.Models.CoreSettingsConfiguration>> GetCommonSettings(CancellationToken cancellationToken = default);

    Task<BungieResponse<Dictionary<string, Models.Common.Models.CoreSystem>>> GetUserSystemOverrides(CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.GlobalAlert[]>> GetGlobalAlerts(
        bool includestreaming,
        CancellationToken cancellationToken = default
    );

}
