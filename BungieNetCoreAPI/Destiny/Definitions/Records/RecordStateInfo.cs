using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordStateInfo
    {
        public DefinitionHashPointer<DestinyUnlockDefinition> ClaimedUnlock { get; }
        public DefinitionHashPointer<DestinyUnlockDefinition> CompleteUnlock { get; }
        public uint FeaturedPriority { get; }

        [JsonConstructor]
        private RecordStateInfo(uint claimedUnlockHash, uint completeUnlockHash, uint featuredPriority)
        {
            ClaimedUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(claimedUnlockHash, "DestinyUnlockDefinition");
            CompleteUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(completeUnlockHash, "DestinyUnlockDefinition");
            FeaturedPriority = featuredPriority;
        }
    }
}
