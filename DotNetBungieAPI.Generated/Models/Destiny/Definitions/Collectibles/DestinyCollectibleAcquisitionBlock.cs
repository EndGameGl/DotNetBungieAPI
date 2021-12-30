using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public sealed class DestinyCollectibleAcquisitionBlock
{

    [JsonPropertyName("acquireMaterialRequirementHash")]
    public uint? AcquireMaterialRequirementHash { get; init; }

    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    public uint? AcquireTimestampUnlockValueHash { get; init; }
}
