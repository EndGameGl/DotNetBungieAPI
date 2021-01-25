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
            ClaimedUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(claimedUnlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            CompleteUnlock = new DefinitionHashPointer<DestinyUnlockDefinition>(completeUnlockHash, DefinitionsEnum.DestinyUnlockDefinition);
            FeaturedPriority = featuredPriority;
        }
    }
}
