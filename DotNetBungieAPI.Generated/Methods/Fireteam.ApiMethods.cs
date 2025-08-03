using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated.Methods;

public interface IFireteamApi
{
    Task<ApiResponse<int>> GetActivePrivateClanFireteamCount(
        long groupId,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
        int activityType,
        Models.Fireteam.FireteamDateRange dateRange,
        long groupId,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        Models.Fireteam.FireteamPublicSearchOption publicOnly,
        Models.Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
        int activityType,
        Models.Fireteam.FireteamDateRange dateRange,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        Models.Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        string authToken
    );

    Task<ApiResponse<Models.SearchResultOfFireteamResponse>> GetMyClanFireteams(
        long groupId,
        bool includeClosed,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        bool groupFilter,
        string langFilter,
        string authToken
    );

    Task<ApiResponse<Models.Fireteam.FireteamResponse>> GetClanFireteam(
        long fireteamId,
        long groupId,
        string authToken
    );

}
