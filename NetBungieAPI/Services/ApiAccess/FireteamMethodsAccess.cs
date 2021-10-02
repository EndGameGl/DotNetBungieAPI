using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
using NetBungieAPI.Clients;
using NetBungieAPI.Exceptions;
using NetBungieAPI.Models;
using NetBungieAPI.Models.Applications;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Fireteam;
using NetBungieAPI.Models.Queries;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services.ApiAccess
{
    public class FireteamMethodsAccess : IFireteamMethodsAccess
    {
        private readonly BungieClientConfiguration _configuration;
        private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

        internal FireteamMethodsAccess(
            IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
            BungieClientConfiguration configuration)
        {
            _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<int>> GetActivePrivateClanFireteamCount(
            AuthorizationTokenData authorizationToken,
            long groupId,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("ActiveCount/")
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<int>(url, cancellationToken, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
            AuthorizationTokenData authorizationToken,
            long groupId,
            FireteamPlatform platform,
            DestinyActivityModeType activityType,
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter,
            FireteamPublicSearchOption publicOnly,
            int page = 0,
            string langFilter = null,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("Available/")
                .AddUrlParam(((byte)platform).ToString())
                .AddUrlParam(((int)activityType).ToString())
                .AddUrlParam(((byte)dateRange).ToString())
                .AddUrlParam(((byte)slotFilter).ToString())
                .AddUrlParam(((byte)publicOnly).ToString())
                .AddUrlParam(page.ToString())
                .AddQueryParam("langFilter", langFilter, () => !string.IsNullOrWhiteSpace(langFilter))
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(url, cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
            AuthorizationTokenData authorizationToken,
            FireteamPlatform platform,
            DestinyActivityModeType activityType,
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter,
            int page = 0,
            string langFilter = null,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Fireteam/Search/Available/")
                .AddUrlParam(((byte)platform).ToString())
                .AddUrlParam(((int)activityType).ToString())
                .AddUrlParam(((byte)dateRange).ToString())
                .AddUrlParam(((byte)slotFilter).ToString())
                .AddUrlParam(page.ToString())
                .AddQueryParam("langFilter", langFilter, () => !string.IsNullOrWhiteSpace(langFilter))
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(url, cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(
            AuthorizationTokenData authorizationToken,
            long groupId,
            FireteamPlatform platform,
            bool includeClosed,
            int page = 0,
            string langFilter = null,
            bool groupFilter = false,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .AddUrlParam(((byte)platform).ToString())
                .Append("My/")
                .AddUrlParam(includeClosed.ToString())
                .AddUrlParam(page.ToString())
                .AddQueryParam("langFilter", langFilter, () => !string.IsNullOrWhiteSpace(langFilter))
                .AddQueryParam("groupFilter", groupFilter.ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(url, cancellationToken,
                    authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }

        public async ValueTask<BungieResponse<FireteamResponse>> GetClanFireteam(
            AuthorizationTokenData authorizationToken,
            long groupId,
            long fireteamId,
            CancellationToken cancellationToken = default)
        {
            if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(cancellationToken)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("Summary/")
                .AddUrlParam(fireteamId.ToString())
                .Build();

            return await _dotNetBungieApiHttpClient
                .GetFromBungieNetPlatform<FireteamResponse>(url, cancellationToken, authorizationToken.AccessToken)
                .ConfigureAwait(false);
        }
    }
}