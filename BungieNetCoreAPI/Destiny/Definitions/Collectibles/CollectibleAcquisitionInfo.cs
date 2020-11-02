using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Collectibles
{
    public class CollectibleAcquisitionInfo
    {
        public bool RunOnlyAcquisitionRewardSite { get; }
        public uint? AcquireMaterialRequirementHash { get; }

        [JsonConstructor]
        private CollectibleAcquisitionInfo(bool runOnlyAcquisitionRewardSite, uint? acquireMaterialRequirementHash)
        {
            RunOnlyAcquisitionRewardSite = runOnlyAcquisitionRewardSite;
            AcquireMaterialRequirementHash = acquireMaterialRequirementHash;
        }
    }
}
