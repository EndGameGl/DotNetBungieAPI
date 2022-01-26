namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public class DestinyCollectibleAcquisitionBlock : IDeepEquatable<DestinyCollectibleAcquisitionBlock>
{
    [JsonPropertyName("acquireMaterialRequirementHash")]
    public uint? AcquireMaterialRequirementHash { get; set; }

    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    public uint? AcquireTimestampUnlockValueHash { get; set; }

    public bool DeepEquals(DestinyCollectibleAcquisitionBlock? other)
    {
        return other is not null &&
               AcquireMaterialRequirementHash == other.AcquireMaterialRequirementHash &&
               AcquireTimestampUnlockValueHash == other.AcquireTimestampUnlockValueHash;
    }
}