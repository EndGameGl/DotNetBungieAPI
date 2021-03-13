using NetBungieApi.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Records
{
    public class RecordStateInfo : IDeepEquatable<RecordStateInfo>
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> ClaimedUnlock { get; }
        public DefinitionHashPointer<DestinyUnlockDefinition> CompleteUnlock { get; }
        public int FeaturedPriority { get; }
        public string ObscuredString { get; }

        [JsonConstructor]
        internal RecordStateInfo(uint claimedUnlockHash, uint completeUnlockHash, int featuredPriority, string obscuredString)
        {
            ClaimedUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(claimedUnlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            CompleteUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(completeUnlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            FeaturedPriority = featuredPriority;
            ObscuredString = obscuredString;
        }

        public bool DeepEquals(RecordStateInfo other)
        {
            return other != null &&
                   ClaimedUnlock.DeepEquals(other.ClaimedUnlock) &&
                   CompleteUnlock.DeepEquals(other.CompleteUnlock) &&
                   FeaturedPriority == other.FeaturedPriority &&
                   ObscuredString == other.ObscuredString;
        }
    }
}
