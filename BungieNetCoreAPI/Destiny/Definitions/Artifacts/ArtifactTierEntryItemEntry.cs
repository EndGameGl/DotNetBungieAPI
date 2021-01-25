using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTierEntryItemEntry
    {
        public uint ActiveUnlockHash { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }

        [JsonConstructor]
        private ArtifactTierEntryItemEntry(uint activeUnlockHash, uint itemHash)
        {
            ActiveUnlockHash = activeUnlockHash;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
