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

internal sealed class AppApi : IAppApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public AppApi(
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
    ///     Get API usage by application for time frame specified. You can go as far back as 30 days ago, and can ask for up to a 48 hour window of time in a single request. You must be authenticated with at least the ReadUserData permission to access this endpoint.
    /// </summary>
    /// <param name="applicationId">ID of the application to get usage statistics.</param>
    /// <param name="end">End time for query. Goes to now if not specified.</param>
    /// <param name="start">Start time for query. Goes to 24 hours ago if not specified.</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Applications.ApiUsage>> GetApplicationApiUsage(
        int applicationId,
        DateTime end,
        DateTime start,
        AuthorizationTokenData authorizationToken,
        CancellationToken cancellationToken = default
    )
    {
        if (!_configuration.HasSufficientRights(ApplicationScopes.ReadUserData))
            throw new InsufficientScopeException(ApplicationScopes.ReadUserData);

        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append($"/App/ApiUsage/{applicationId}/")
            .AddQueryParam("end", end)
            .AddQueryParam("start", start)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Applications.ApiUsage>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get list of applications created by Bungie.
    /// </summary>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Applications.Application[]>> GetBungieApplications(CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Applications.Application[]>("/App/FirstParty/", cancellationToken);
    }

}
