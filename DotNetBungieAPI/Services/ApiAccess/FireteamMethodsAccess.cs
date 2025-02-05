﻿using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Models.Fireteam;
using DotNetBungieAPI.Models.Queries;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class FireteamMethodsAccess : IFireteamMethodsAccess
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public FireteamMethodsAccess(
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieClientConfiguration configuration
    )
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _configuration = configuration;
    }

    public async Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(
        AuthorizationTokenData authorizationToken,
        long groupId,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/Fireteam/Clan/")
            .AddUrlParam(groupId.ToString())
            .Append("ActiveCount/")
            .Build();

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<int>(
            url,
            cancellationToken,
            authorizationToken.AccessToken
        );
    }

    public async Task<BungieResponse<SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
        AuthorizationTokenData authorizationToken,
        long groupId,
        FireteamPlatform platform,
        DestinyActivityModeType activityType,
        FireteamDateRange dateRange,
        FireteamSlotSearch slotFilter,
        FireteamPublicSearchOption publicOnly,
        int page = 0,
        string langFilter = null,
        CancellationToken cancellationToken = default
    )
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

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(
            url,
            cancellationToken,
            authorizationToken.AccessToken
        );
    }

    public async Task<
        BungieResponse<SearchResultOfFireteamSummary>
    > SearchPublicAvailableClanFireteams(
        AuthorizationTokenData authorizationToken,
        FireteamPlatform platform,
        DestinyActivityModeType activityType,
        FireteamDateRange dateRange,
        FireteamSlotSearch slotFilter,
        int page = 0,
        string langFilter = null,
        CancellationToken cancellationToken = default
    )
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

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(
            url,
            cancellationToken,
            authorizationToken.AccessToken
        );
    }

    public async ValueTask<BungieResponse<SearchResultOfFireteamSummary>> GetMyClanFireteams(
        AuthorizationTokenData authorizationToken,
        long groupId,
        FireteamPlatform platform,
        bool includeClosed,
        int page = 0,
        string langFilter = null,
        bool groupFilter = false,
        CancellationToken cancellationToken = default
    )
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

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<SearchResultOfFireteamSummary>(
            url,
            cancellationToken,
            authorizationToken.AccessToken
        );
    }

    public async ValueTask<BungieResponse<FireteamResponse>> GetClanFireteam(
        AuthorizationTokenData authorizationToken,
        long groupId,
        long fireteamId,
        CancellationToken cancellationToken = default
    )
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

        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<FireteamResponse>(
            url,
            cancellationToken,
            authorizationToken.AccessToken
        );
    }
}
