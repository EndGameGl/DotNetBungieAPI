using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactTierItem
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public bool IsActive { get; init; }

        [JsonConstructor]
        internal DestinyArtifactTierItem(uint itemHash, bool isActive)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            IsActive = isActive;
        }
    }
}
