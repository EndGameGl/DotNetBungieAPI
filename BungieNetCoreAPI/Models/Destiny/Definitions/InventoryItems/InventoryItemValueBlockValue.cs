using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemValueBlockValue : IDeepEquatable<InventoryItemValueBlockValue>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public long? ItemInstanceId { get; init; }
        public int Quantity { get; init; }

        [JsonConstructor]
        internal InventoryItemValueBlockValue(uint itemHash, int quantity, long? itemInstanceId)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            ItemInstanceId = itemInstanceId;
        }

        public bool DeepEquals(InventoryItemValueBlockValue other)
        {
            return other != null &&
                   Item.DeepEquals(other.Item) &&
                   ItemInstanceId == other.ItemInstanceId &&
                   Quantity == other.Quantity;
        }
    }
}
