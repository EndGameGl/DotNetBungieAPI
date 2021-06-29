﻿using System.Threading;
using System.Threading.Tasks;
using NetBungieAPI.Authorization;
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
        private readonly IConfigurationService _configuration;
        private readonly IHttpClientInstance _httpClient;

        public FireteamMethodsAccess(IHttpClientInstance httpClient, IConfigurationService configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async ValueTask<BungieResponse<int>> GetActivePrivateClanFireteamCount(
            AuthorizationTokenData authData,
            long groupId,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("ActiveCount/")
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<int>(url, token, authData.AccessToken);
        }

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
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("Available/")
                .AddUrlParam(((byte) platform).ToString())
                .AddUrlParam(((int) activityType).ToString())
                .AddUrlParam(((byte) dateRange).ToString())
                .AddUrlParam(((byte) slotFilter).ToString())
                .AddUrlParam(((byte) publicOnly).ToString())
                .AddUrlParam(page.ToString())
                .AddQueryParam("langFilter", langFilter, () => !string.IsNullOrWhiteSpace(langFilter))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(url, token,
                authData.AccessToken);
        }

        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
            AuthorizationTokenData authData,
            FireteamPlatform platform,
            DestinyActivityModeType activityType,
            FireteamDateRange dateRange,
            FireteamSlotSearch slotFilter,
            int page = 0,
            string langFilter = null,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Fireteam/Search/Available/")
                .AddUrlParam(((byte) platform).ToString())
                .AddUrlParam(((int) activityType).ToString())
                .AddUrlParam(((byte) dateRange).ToString())
                .AddUrlParam(((byte) slotFilter).ToString())
                .AddUrlParam(page.ToString())
                .AddQueryParam("langFilter", langFilter, () => !string.IsNullOrWhiteSpace(langFilter))
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(url, token,
                authData.AccessToken);
        }

        public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(
            AuthorizationTokenData authData,
            long groupId,
            FireteamPlatform platform,
            bool includeClosed,
            int page = 0,
            string langFilter = null,
            bool groupFilter = false,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .AddUrlParam(((byte) platform).ToString())
                .Append("My/")
                .AddUrlParam(includeClosed.ToString())
                .AddUrlParam(page.ToString())
                .AddQueryParam("langFilter", langFilter, () => !string.IsNullOrWhiteSpace(langFilter))
                .AddQueryParam("groupFilter", groupFilter.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(url, token,
                authData.AccessToken);
        }

        public async ValueTask<BungieResponse<FireteamResponse>> GetClanFireteam(
            AuthorizationTokenData authData,
            long groupId,
            long fireteamId,
            CancellationToken token = default)
        {
            if (!_configuration.Settings.IdentificationSettings.ApplicationScopes.HasFlag(ApplicationScopes.ReadGroups))
                throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

            var url = StringBuilderPool
                .GetBuilder(token)
                .Append("/Fireteam/Clan/")
                .AddUrlParam(groupId.ToString())
                .Append("Summary/")
                .AddUrlParam(fireteamId.ToString())
                .Build();

            return await _httpClient.GetFromBungieNetPlatform<FireteamResponse>(url, token,
                authData.AccessToken);
        }
    }
}