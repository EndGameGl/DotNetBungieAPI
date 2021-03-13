using NetBungieApi.Destiny.Definitions.InventoryItems;
using NetBungieApi.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Milestones
{
    /// <summary>
    /// A subclass of DestinyItemQuantity, that provides not just the item and its quantity but also information that BNet can - at some point - use internally to provide more robust runtime information about the item's qualities.
    /// </summary>
    public class MilestoneItem : IDeepEquatable<MilestoneItem>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }
        public long? ItemInstanceId { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public int? VendorItemIndex { get; }

        [JsonConstructor]
        internal MilestoneItem(uint itemHash, int quantity, long? itemInstanceId, int? vendorItemIndex, uint? vendorHash)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            ItemInstanceId = itemInstanceId;
            VendorItemIndex = vendorItemIndex;
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
        }

        public bool DeepEquals(MilestoneItem other)
        {
            return other != null &&
                   Item.DeepEquals(other.Item) &&
                   Quantity == other.Quantity &&
                   ItemInstanceId == other.ItemInstanceId &&
                   Vendor.DeepEquals(other.Vendor) &&
                   VendorItemIndex == other.VendorItemIndex;
        }
    }
}
