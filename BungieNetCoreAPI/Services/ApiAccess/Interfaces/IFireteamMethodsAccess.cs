using NetBungieAPI.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Fireteam;
using NetBungieAPI.Models.Queries;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IFireteamMethodsAccess
    {
        Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(long groupId);
        Task<BungieResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(long groupId, FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange, FireteamSlotSearch slotFilter, FireteamPublicSearchOption publicOnly, int page = 0);
        Task<BungieResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange, FireteamSlotSearch slotFilter, int page = 0, string langFilter = null);
        Task<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(long groupId, FireteamPlatform platform, bool includeClosed, int page = 0, string langFilter = null, bool groupFilter = false); 
        Task<BungieResponse<FireteamResponse>> GetClanFireteam(long groupId, long fireteamId);
    }
}
