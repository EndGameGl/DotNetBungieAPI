using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Rendering;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.ApiAccess;

namespace DotNetBungieAPI.Services.ApiAccess;

internal sealed class RenderApiAccess : IRenderApiAccess
{
    private readonly IDotNetBungieApiHttpClient _httpClient;
    private readonly IBungieNetJsonSerializer _bungieNetJsonSerializer;

    public RenderApiAccess(
        IDotNetBungieApiHttpClient httpClient,
        IBungieNetJsonSerializer bungieNetJsonSerializer)
    {
        _httpClient = httpClient;
        _bungieNetJsonSerializer = bungieNetJsonSerializer;
    }

    public async ValueTask<DestinyGearAssetDefinitionGear> GetDestinyGearAssetDefinitionGearData(
        string gearPath,
        DestinyManifest manifest,
        string game = "destiny2",
        CancellationToken cancellationToken = default)
    {
        var gearContentPath = StringBuilderPool
            .GetBuilder(cancellationToken)
            .Append(string.Format(manifest.MobileGearCDN["Gear"], game))
            .Append($"/{gearPath}")
            .Build();

        var stream = await _httpClient.GetStreamFromWebSourceAsync(gearContentPath);
        return await _bungieNetJsonSerializer.DeserializeAsync<DestinyGearAssetDefinitionGear>(stream.ContentStream);
    }
}