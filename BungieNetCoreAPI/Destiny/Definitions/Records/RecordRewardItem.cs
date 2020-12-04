using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordRewardItem
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }

        [JsonConstructor]
        private RecordRewardItem(uint itemHash, int quantity)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition");
            Quantity = quantity;
        }
    }
}
