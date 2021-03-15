using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorItemQuantity : IDeepEquatable<VendorItemQuantity>
    {
        public int ScalarDenominator { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }
        public long? ItemInstanceId { get; }

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
