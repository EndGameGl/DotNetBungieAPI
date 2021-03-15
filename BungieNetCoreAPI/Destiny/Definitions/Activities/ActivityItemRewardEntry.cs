using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// Used in a number of Destiny contracts to return data about an item stack and its quantity. Can optionally return an itemInstanceId if the item is instanced - in which case, the quantity returned will be 1. If it's not... uh, let me know okay? Thanks.
    /// </summary>
    public class ActivityItemRewardEntry : IDeepEquatable<ActivityItemRewardEntry>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        /// <summary>
        /// The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.
        /// </summary>
        public int Quantity { get; }
        /// <summary>
        /// If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally, this will be null.
        /// </summary>
        public uint? ItemInstanceId { get; }

        [JsonConstructor]
        internal ActivityItemRewardEntry(uint itemHash, int quantity, uint? itemInstanceId)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            ItemInstanceId = itemInstanceId;
        }

        public bool DeepEquals(ActivityItemRewardEntry other)
        {
            return other != null &&
                Item.DeepEquals(other.Item) &&
                Quantity == other.Quantity &&
                ItemInstanceId == other.ItemInstanceId;
        }
    }
}
