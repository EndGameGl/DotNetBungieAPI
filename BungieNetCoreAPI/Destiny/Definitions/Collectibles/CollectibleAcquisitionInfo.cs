using NetBungieAPI.Destiny.Definitions.MaterialRequirementSets;
using NetBungieAPI.Destiny.Definitions.UnlockValues;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Collectibles
{
    public class CollectibleAcquisitionInfo : IDeepEquatable<CollectibleAcquisitionInfo>
    {
        public bool RunOnlyAcquisitionRewardSite { get; }
        public DefinitionHashPointer<DestinyMaterialRequirementSetDefinition> AcquireMaterialRequirement { get; }
        public DefinitionHashPointer<DestinyUnlockValueDefinition> AcquireTimestampUnlockValue { get; }

        [JsonConstructor]
        internal CollectibleAcquisitionInfo(bool runOnlyAcquisitionRewardSite, uint? acquireMaterialRequirementHash, uint? acquireTimestampUnlockValueHash)
        {
            RunOnlyAcquisitionRewardSite = runOnlyAcquisitionRewardSite;
            AcquireMaterialRequirement = new DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>(acquireMaterialRequirementHash, DefinitionsEnum.DestinyMaterialRequirementSetDefinition);
            AcquireTimestampUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(acquireTimestampUnlockValueHash, DefinitionsEnum.DestinyUnlockValueDefinition);
        }

        public bool DeepEquals(CollectibleAcquisitionInfo other)
        {
            return other != null &&
                RunOnlyAcquisitionRewardSite == other.RunOnlyAcquisitionRewardSite &&
                AcquireMaterialRequirement.DeepEquals(other.AcquireMaterialRequirement) &&
                AcquireTimestampUnlockValue.DeepEquals(other.AcquireTimestampUnlockValue);
        }
    }
}
