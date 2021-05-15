using System.Threading;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Fireteam;
using NetBungieAPI.Models.Queries;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;

namespace NetBungieAPI.Services.ApiAccess.Interfaces
{
    public interface IFireteamMethodsAccess
    {
        /// <summary>
        /// Gets a count of all active non-public fireteams for the specified clan. Maximum value returned is 25.
        /// </summary>
        /// <param name="groupId">Group ID</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<int>> GetActivePrivateClanFireteamCount(
            AuthorizationTokenData authData,
            long groupId,
            CancellationToken token = default);

        /// <summary>
        /// Gets a listing of all of this clan's fireteams that are have available slots. Caller is not checked for join criteria so caching is maximized.
        /// </summary>
        /// <param name="groupId">The group id of the clan.</param>
        /// <param name="platform">The platform filter.</param>
        /// <param name="activityType">The activity type to filter by.</param>
        /// <param name="dateRange">The date range to grab available fireteams.</param>
        /// <param name="slotFilter">Filters based on available slots</param>
        /// <param name="publicOnly">Determines public/private filtering</param>
        /// <param name="page">Zero based page</param>
        /// <param name="langFilter">An optional language filter.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
            AuthorizationTokenData authData,
            long groupId,
            FireteamPlatform platform, 
            DestinyActivityModeType activityType, 
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter, 
            FireteamPublicSearchOption publicOnly,
            int page = 0,
            string langFilter = null,
            CancellationToken token = default);

        /// <summary>
        /// Gets a listing of all public fireteams starting now with open slots. Caller is not checked for join criteria so caching is maximized.
        /// </summary>
        /// <param name="platform">The platform filter.</param>
        /// <param name="activityType">The activity type to filter by.</param>
        /// <param name="dateRange">The date range to grab available fireteams.</param>
        /// <param name="slotFilter">Filters based on available slots</param>
        /// <param name="page">Zero based page</param>
        /// <param name="langFilter">An optional language filter.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
            AuthorizationTokenData authData,
            FireteamPlatform platform, 
            DestinyActivityModeType activityType, 
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter,
            int page = 0, 
            string langFilter = null, 
            CancellationToken token = default);

        /// <summary>
        /// Gets a listing of all fireteams that caller is an applicant, a member, or an alternate of.
        /// </summary>
        /// <param name="groupId">The group id of the clan. (This parameter is ignored unless the optional query parameter groupFilter is true).</param>
        /// <param name="platform">The platform filter.</param>
        /// <param name="includeClosed">If true, return fireteams that have been closed.</param>
        /// <param name="page">Deprecated parameter, ignored.</param>
        /// <param name="langFilter">An optional language filter.</param>
        /// <param name="groupFilter">If true, filter by clan. Otherwise, ignore the clan and show all of the user's fireteams.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(
            AuthorizationTokenData authData,
            long groupId,
            FireteamPlatform platform, 
            bool includeClosed, 
            int page = 0, 
            string langFilter = null,
            bool groupFilter = false, 
            CancellationToken token = default);

        /// <summary>
        /// Gets a specific fireteam.
        /// </summary>
        /// <param name="groupId">The group id of the clan.</param>
        /// <param name="fireteamId">The unique id of the fireteam.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        ValueTask<BungieResponse<FireteamResponse>> GetClanFireteam(
            AuthorizationTokenData authData,
            long groupId, 
            long fireteamId,
            CancellationToken token = default);
    }
}