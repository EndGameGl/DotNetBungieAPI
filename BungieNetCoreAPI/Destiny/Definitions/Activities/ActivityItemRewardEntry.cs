using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using Unity;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityItemRewardEntry
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }

        [JsonConstructor]
        private ActivityItemRewardEntry(uint itemHash, int quantity)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition");
            Quantity = quantity;
        }
    }
}
