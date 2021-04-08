using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorItemQuantity : IDeepEquatable<VendorItemQuantity>
    {
        public int ScalarDenominator { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public int Quantity { get; init; }
        public long? ItemInstanceId { get; init; }

        [JsonConstructor]
        internal VendorItemQuantity(int scalarDenominator, uint itemHash, int quantity, long? itemInstanceId)
        {
            ScalarDenominator = scalarDenominator;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            ItemInstanceId = itemInstanceId;
        }

        public bool DeepEquals(VendorItemQuantity other)
        {
            return other != null &&
                   ScalarDenominator == other.ScalarDenominator &&
                   Item.DeepEquals(other.Item) &&
                   Quantity == other.Quantity &&
                   ItemInstanceId == other.ItemInstanceId;
        }
    }
}
