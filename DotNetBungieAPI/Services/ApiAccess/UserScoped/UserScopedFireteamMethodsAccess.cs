using DotNetBungieAPI.Authorization;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using DotNetBungieAPI.Models.Fireteam;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Services.ApiAccess.UserScoped
{
    public sealed class UserScopedFireteamMethodsAccess
    {
        private readonly IFireteamMethodsAccess _apiAccess;
        private readonly AuthorizationTokenData _token;

        internal UserScopedFireteamMethodsAccess(
            IFireteamMethodsAccess apiAccess,
            AuthorizationTokenData token)
        {
            _apiAccess = apiAccess;
            _token = token;
        }

        /// <summary>
        ///     <inheritdoc cref="IFireteamMethodsAccess.GetActivePrivateClanFireteamCount" />
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<int>> GetActivePrivateClanFireteamCount(
            long groupId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetActivePrivateClanFireteamCount(_token, groupId, token);
        }

        /// <summary>
        ///     <inheritdoc cref="IFireteamMethodsAccess.GetActivePrivateClanFireteamCount" />
        /// </summary>
        /// <param name="authData"></param>
        /// <param name="groupId"></param>
        /// <param name="platform"></param>
        /// <param name="activityType"></param>
        /// <param name="dateRange"></param>
        /// <param name="slotFilter"></param>
        /// <param name="publicOnly"></param>
        /// <param name="page"></param>
        /// <param name="langFilter"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
            AuthorizationTokenData authData,
            long groupId,
            FireteamPlatform platform,
            DestinyActivityModeType activityType,
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter,
            FireteamPublicSearchOption publicOnly,
            int page = 0,
            string langFilter = null,
            CancellationToken token = default)
        {
            return await _apiAccess.GetAvailableClanFireteams(_token, groupId, platform, activityType, dateRange,
                slotFilter, publicOnly, page, langFilter, token);
        }

        /// <summary>
        ///     <inheritdoc cref="IFireteamMethodsAccess.GetActivePrivateClanFireteamCount" />
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="activityType"></param>
        /// <param name="dateRange"></param>
        /// <param name="slotFilter"></param>
        /// <param name="page"></param>
        /// <param name="langFilter"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
            FireteamPlatform platform,
            DestinyActivityModeType activityType,
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter,
            int page = 0,
            string langFilter = null,
            CancellationToken token = default)
        {
            return await _apiAccess.SearchPublicAvailableClanFireteams(_token, platform, activityType, dateRange,
                slotFilter, page, langFilter, token);
        }

        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(
            long groupId,
            FireteamPlatform platform,
            bool includeClosed,
            int page = 0,
            string langFilter = null,
            bool groupFilter = false,
            CancellationToken token = default)
        {
            return await _apiAccess.GetMyClanFireteams(_token, groupId, platform, includeClosed, page, langFilter,
                groupFilter, token);
        }

        public async ValueTask<BungieResponse<FireteamResponse>> GetClanFireteam(
            long groupId,
            long fireteamId,
            CancellationToken token = default)
        {
            return await _apiAccess.GetClanFireteam(_token, groupId, fireteamId, token);
        }
    }
}