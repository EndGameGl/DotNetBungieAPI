using DotNetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;
using DotNetBungieAPI.Models.Destiny.Definitions.UnlockValues;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;

public sealed record DestinyCollectibleAcquisitionBlock : IDeepEquatable<DestinyCollectibleAcquisitionBlock>
{
    [JsonPropertyName("runOnlyAcquisitionRewardSite")]
    public bool RunOnlyAcquisitionRewardSite { get; init; }

    [JsonPropertyName("acquireMaterialRequirementHash")]
    public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>
        AcquireMaterialRequirement { get; init; } =
        DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>.Empty;

    [JsonPropertyName("acquireTimestampUnlockValueHash")]
    public DefinitionHashPointer<DestinyUnlockValueDefinition> AcquireTimestampUnlockValue { get; init; } =
        DefinitionHashPointer<DestinyUnlockValueDefinition>.Empty;

    public bool DeepEquals(DestinyCollectibleAcquisitionBlock other)
    {
        return other != null &&
               RunOnlyAcquisitionRewardSite == other.RunOnlyAcquisitionRewardSite &&
               AcquireMaterialRequirement.DeepEquals(other.AcquireMaterialRequirement) &&
               AcquireTimestampUnlockValue.DeepEquals(other.AcquireTimestampUnlockValue);
    }
}