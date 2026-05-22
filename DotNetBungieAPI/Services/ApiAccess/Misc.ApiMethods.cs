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

internal sealed class MiscApi : IMiscApi
{
    private readonly IBungieClientConfiguration _configuration;
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;
    private readonly IBungieNetJsonSerializer _serializer;

    public MiscApi(
        IBungieClientConfiguration configuration,
        IDotNetBungieApiHttpClient dotNetBungieApiHttpClient,
        IBungieNetJsonSerializer serializer
    )
    {
        _configuration = configuration;
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
        _serializer = serializer;
    }

    /// <summary>
    ///     List of available localization cultures
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, string>>("/GetAvailableLocales/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get the common settings used by the Bungie.Net environment.
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.Common.Models.CoreSettingsConfiguration>> GetCommonSettings(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.Common.Models.CoreSettingsConfiguration>("/Settings/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Get the user-specific system overrides that should be respected alongside common systems.
    /// </summary>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Dictionary<string, Models.Common.Models.CoreSystem>>> GetUserSystemOverrides(AuthorizationTokenData? authorizationToken = null, CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Dictionary<string, Models.Common.Models.CoreSystem>>("/UserSystemOverrides/", cancellationToken, authToken: authorizationToken?.AccessToken);
    }

    /// <summary>
    ///     Gets any active global alert for display in the forum banners, help pages, etc. Usually used for DOC alerts.
    /// </summary>
    /// <param name="includestreaming">Determines whether Streaming Alerts are included in results</param>
    /// <param name="authorizationToken">Authorization information</param>
    /// <param name="cancellationToken">Method cancellation token</param>
    public async Task<BungieResponse<Models.GlobalAlert[]>> GetGlobalAlerts(
        bool includestreaming,
        AuthorizationTokenData? authorizationToken = null,
        CancellationToken cancellationToken = default
    )
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .AddQueryParam("includestreaming", includestreaming)
            .Build();
        return await _dotNetBungieApiHttpClient.GetFromBungieNetPlatform<Models.GlobalAlert[]>(url, cancellationToken, authToken: authorizationToken?.AccessToken);
    }

}
