using NetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;
using NetBungieAPI.Models.Destiny.Definitions.UnlockValues;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Collectibles
{
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
}