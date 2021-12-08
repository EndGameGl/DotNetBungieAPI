using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Common;
using DotNetBungieAPI.Services.ApiAccess.Interfaces;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class MiscMethodsAccess : IMiscMethodsAccess
{
    private readonly IDotNetBungieApiHttpClient _dotNetBungieApiHttpClient;

    public MiscMethodsAccess(IDotNetBungieApiHttpClient dotNetBungieApiHttpClient)
    {
        _dotNetBungieApiHttpClient = dotNetBungieApiHttpClient;
    }

    public async ValueTask<BungieResponse<Dictionary<string, string>>> GetAvailableLocales(
        CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<Dictionary<string, string>>("/GetAvailableLocales/", cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<CoreSettingsConfiguration>> GetCommonSettings(
        CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<CoreSettingsConfiguration>("/Settings/", cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<Dictionary<string, CoreSystem>>> GetUserSystemOverrides(
        CancellationToken cancellationToken = default)
    {
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<Dictionary<string, CoreSystem>>("/UserSystemOverrides/", cancellationToken)
            .ConfigureAwait(false);
    }

    public async ValueTask<BungieResponse<GlobalAlert[]>> GetGlobalAlerts(
        bool includestreaming = false,
        CancellationToken cancellationToken = default)
    {
        var url = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append("/GlobalAlerts/")
            .AddQueryParam("includestreaming", includestreaming.ToString())
            .Build();
        return await _dotNetBungieApiHttpClient
            .GetFromBungieNetPlatform<GlobalAlert[]>(url, cancellationToken)
            .ConfigureAwait(false);
    }
}