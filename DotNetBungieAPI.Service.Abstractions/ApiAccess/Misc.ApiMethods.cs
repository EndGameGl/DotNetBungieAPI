using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IMiscApi
{
    Task<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.Common.Models.CoreSettingsConfiguration>> GetCommonSettings(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<Dictionary<string, Models.Common.Models.CoreSystem>>> GetUserSystemOverrides(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default);

    Task<BungieResponse<Models.GlobalAlert[]>> GetGlobalAlerts(
        bool includestreaming,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    );

}
