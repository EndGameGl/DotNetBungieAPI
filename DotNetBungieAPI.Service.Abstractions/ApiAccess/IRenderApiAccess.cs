using DotNetBungieAPI.Models.Destiny.Config;
using DotNetBungieAPI.Models.Destiny.Rendering;

namespace DotNetBungieAPI.Service.Abstractions.ApiAccess;

public interface IRenderApiAccess
{
    ValueTask<DestinyGearAssetDefinitionGear> GetDestinyGearAssetDefinitionGearData(
        string gearPath,
        DestinyManifest manifest,
        string game = "destiny2",
        CancellationToken cancellationToken = default);
}