namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public class DestinyCollectibleAcquisitionBlock
{
    [Destiny2Definition<Destiny.Definitions.DestinyMaterialRequirementSetDefinition>("Destiny.Definitions.DestinyMaterialRequirementSetDefinition")]
    [JsonPropertyName("acquireMaterialRequirementHash")]
    public uint? AcquireMaterialRequirementHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyUnlockValueDefinition>("Destiny.Definitions.DestinyUnlockValueDefinition")]
    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    public uint? AcquireTimestampUnlockValueHash { get; set; }
}
