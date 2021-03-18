using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Fireteam;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IFireteamMethodsAccess
    {
        Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(long groupId);
        Task<BungieResponse<SearchResult<FireteamSummary[]>>> GetAvailableClanFireteams(long groupId, FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange, FireteamSlotSearch slotFilter, FireteamPublicSearchOption publicOnly, int page = 0);
        Task<BungieResponse<SearchResult<FireteamSummary[]>>> SearchPublicAvailableClanFireteams(FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange, FireteamSlotSearch slotFilter, int page = 0, string langFilter = null);
        Task<BungieResponse<SearchResult<FireteamResponse[]>>> GetMyClanFireteams(long groupId, FireteamPlatform platform, bool includeClosed, int page = 0, string langFilter = null, bool groupFilter = false); 
        Task<BungieResponse<FireteamResponse>> GetClanFireteam(long groupId, long fireteamId);
    }
}
