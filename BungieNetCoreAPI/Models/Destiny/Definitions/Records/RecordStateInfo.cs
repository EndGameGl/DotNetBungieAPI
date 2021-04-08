using NetBungieAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordStateInfo : IDeepEquatable<RecordStateInfo>
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> ClaimedUnlock { get; init; }
        public DefinitionHashPointer<DestinyUnlockDefinition> CompleteUnlock { get; init; }
        public int FeaturedPriority { get; init; }
        public string ObscuredString { get; init; }

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
