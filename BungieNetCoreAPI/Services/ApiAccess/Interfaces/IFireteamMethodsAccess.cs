using System.Threading;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Fireteam;
using NetBungieAPI.Models.Queries;
using System.Threading.Tasks;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IFireteamMethodsAccess
    {
        ValueTask<BungieResponse<int>> GetActivePrivateClanFireteamCount(long groupId,
            CancellationToken token = default);

        ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(long groupId,
            FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter, FireteamPublicSearchOption publicOnly, int page = 0,
            string langFilter = null,
            CancellationToken token = default);

        ValueTask<BungieResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
            FireteamPlatform platform, DestinyActivityModeType activityType, FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter, int page = 0, string langFilter = null, CancellationToken token = default);

        ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(long groupId,
            FireteamPlatform platform, bool includeClosed, int page = 0, string langFilter = null,
            bool groupFilter = false, CancellationToken token = default);

        ValueTask<BungieResponse<FireteamResponse>> GetClanFireteam(long groupId, long fireteamId,
            CancellationToken token = default);
    }
}