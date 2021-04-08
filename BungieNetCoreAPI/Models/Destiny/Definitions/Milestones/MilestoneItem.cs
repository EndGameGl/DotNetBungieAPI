using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    /// <summary>
    /// A subclass of DestinyItemQuantity, that provides not just the item and its quantity but also information that BNet can - at some point - use internally to provide more robust runtime information about the item's qualities.
    /// </summary>
    public class MilestoneItem : IDeepEquatable<MilestoneItem>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public int Quantity { get; init; }
        public long? ItemInstanceId { get; init; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; }
        public int? VendorItemIndex { get; init; }

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
