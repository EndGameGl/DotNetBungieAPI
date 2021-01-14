using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneItem
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }

        [JsonConstructor]
        private MilestoneItem(uint itemHash, int quantity)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition");
            Quantity = quantity;
        }
    }
}
