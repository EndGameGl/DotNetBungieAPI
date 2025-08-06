using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Models.Authorization;
using DotNetBungieAPI.Models.Exceptions;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class FireteamApi : IFireteamApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public FireteamApi(
        IBungieClientConfiguration configuration,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer serializer
    )
    {
        _configuration = _configuration;
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    /// <summary>
    ///     Gets a count of all active non-public fireteams for the specified clan. Maximum value returned is 25.
    /// </summary>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<int>> GetActivePrivateClanFireteamCount(
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Fireteam/Clan/{groupId}/ActiveCount/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<int>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets a listing of all of this clan's fireteams that are have available slots. Caller is not checked for join criteria so caching is maximized.
    /// </summary>
    /// <param name="activityType">The activity type to filter by.</param>
    /// <param name="dateRange">The date range to grab available fireteams.</param>
    /// <param name="excludeImmediate">If you wish the result to exclude immediate fireteams, set this to true. Immediate-only can be forced using the dateRange enum.</param>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Zero based page</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="publicOnly">Determines public/private filtering.</param>
    /// <param name="slotFilter">Filters based on available slots</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfFireteamSummary>> GetAvailableClanFireteams(
        int activityType,
        Models.Fireteam.FireteamDateRange dateRange,
        long groupId,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        Models.Fireteam.FireteamPublicSearchOption publicOnly,
        Models.Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Fireteam/Clan/{groupId}/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{publicOnly}/{page}/")
            .AddQueryParam("excludeImmediate", excludeImmediate)
            .AddQueryParam("langFilter", langFilter)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfFireteamSummary>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets a listing of all public fireteams starting now with open slots. Caller is not checked for join criteria so caching is maximized.
    /// </summary>
    /// <param name="activityType">The activity type to filter by.</param>
    /// <param name="dateRange">The date range to grab available fireteams.</param>
    /// <param name="excludeImmediate">If you wish the result to exclude immediate fireteams, set this to true. Immediate-only can be forced using the dateRange enum.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Zero based page</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="slotFilter">Filters based on available slots</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfFireteamSummary>> SearchPublicAvailableClanFireteams(
        int activityType,
        Models.Fireteam.FireteamDateRange dateRange,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        Models.Fireteam.FireteamSlotSearch slotFilter,
        bool excludeImmediate,
        string langFilter,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Fireteam/Search/Available/{platform}/{activityType}/{dateRange}/{slotFilter}/{page}/")
            .AddQueryParam("excludeImmediate", excludeImmediate)
            .AddQueryParam("langFilter", langFilter)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfFireteamSummary>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets a listing of all fireteams that caller is an applicant, a member, or an alternate of.
    /// </summary>
    /// <param name="groupFilter">If true, filter by clan. Otherwise, ignore the clan and show all of the user's fireteams.</param>
    /// <param name="groupId">The group id of the clan. (This parameter is ignored unless the optional query parameter groupFilter is true).</param>
    /// <param name="includeClosed">If true, return fireteams that have been closed.</param>
    /// <param name="langFilter">An optional language filter.</param>
    /// <param name="page">Deprecated parameter, ignored.</param>
    /// <param name="platform">The platform filter.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.SearchResultOfFireteamResponse>> GetMyClanFireteams(
        long groupId,
        bool includeClosed,
        int page,
        Models.Fireteam.FireteamPlatform platform,
        bool groupFilter,
        string langFilter,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Fireteam/Clan/{groupId}/My/{platform}/{includeClosed}/{page}/")
            .AddQueryParam("groupFilter", groupFilter)
            .AddQueryParam("langFilter", langFilter)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.SearchResultOfFireteamResponse>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets a specific fireteam.
    /// </summary>
    /// <param name="fireteamId">The unique id of the fireteam.</param>
    /// <param name="groupId">The group id of the clan.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Fireteam.FireteamResponse>> GetClanFireteam(
        long fireteamId,
        long groupId,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadGroups))
            throw new InsufficientScopeException(ApplicationScopes.ReadGroups);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/Fireteam/Clan/{groupId}/Summary/{fireteamId}/")
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Fireteam.FireteamResponse>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

}
