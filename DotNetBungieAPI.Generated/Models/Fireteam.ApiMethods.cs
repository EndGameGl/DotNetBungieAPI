namespace DotNetBungieAPI.Generated.Models;

public interface IFireteamApi
{
    Task<ApiResponse<int>> GetActivePrivateClanFireteamCount(
        long groupId,
        string authToken
    );

    Task<ApiResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
        int activityType,
        Fireteam.FireteamDateRange dateRange,
        long groupId,
        int page,
        Fireteam.FireteamPlatform platform,
        Fireteam.FireteamPublicSearchOption publicOnly,
        Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        string authToken
    );

    Task<ApiResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
        int activityType,
        Fireteam.FireteamDateRange dateRange,
        int page,
        Fireteam.FireteamPlatform platform,
        Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        string authToken
    );

    Task<ApiResponse<SearchResultOfFireteamResponse>> GetMyClanFireteams(
        long groupId,
        bool includeClosed,
        int page,
        Fireteam.FireteamPlatform platform,
        bool groupFilter,
        string langFilter,
        string authToken
    );

    Task<ApiResponse<Fireteam.FireteamResponse>> GetClanFireteam(
        long fireteamId,
        long groupId,
        string authToken
    );

}
