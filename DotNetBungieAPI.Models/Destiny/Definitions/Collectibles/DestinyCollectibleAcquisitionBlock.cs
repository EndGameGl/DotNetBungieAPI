namespace DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;

public sealed class DestinyCollectibleAcquisitionBlock
{
    [JsonPropertyName("acquireMaterialRequirementHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyMaterialRequirementSetDefinition> AcquireMaterialRequirementHash { get; init; }

    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyUnlockValueDefinition> AcquireTimestampUnlockValueHash { get; init; }
}
