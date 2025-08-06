using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IFireteamApi
{
    Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
        int activityType,
        Models.Fireteam.FireteamDateRange dateRange,
        long groupId,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        Models.Fireteam.FireteamPublicSearchOption publicOnly,
        Models.Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
        int activityType,
        Models.Fireteam.FireteamDateRange dateRange,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        Models.Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.SearchResultOfFireteamResponse>> GetMyClanFireteams(
        long groupId,
        bool includeClosed,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        bool groupFilter,
        string langFilter,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

    Task<BungieResponse<Models.Fireteam.FireteamResponse>> GetClanFireteam(
        long fireteamId,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    );

}
