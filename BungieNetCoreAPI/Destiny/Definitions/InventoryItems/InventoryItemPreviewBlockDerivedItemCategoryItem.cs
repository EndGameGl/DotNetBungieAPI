using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// This is a reference to, and summary data for, a specific item that you can get as a result of Using or Acquiring some other Item (For example, this could be summary information for an Emote that you can get by opening an an Eververse Box)
    /// </summary>
    public class InventoryItemPreviewBlockDerivedItemCategoryItem : IDeepEquatable<InventoryItemPreviewBlockDerivedItemCategoryItem>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        /// <summary>
        /// The name of the derived item.
        /// </summary>
        public string ItemName { get; }
        /// <summary>
        /// Additional details about the derived item, in addition to the description.
        /// </summary>
        public string ItemDetail { get; }
        /// <summary>
        /// A brief description of the item
        /// </summary>
        public string ItemDescription { get; }
        /// <summary>
        /// An icon for the item.
        /// </summary>
        public string IconPath { get; }
        /// <summary>
        /// If the item was derived from a "Preview Vendor", this will be an index into the DestinyVendorDefinition's itemList property. Otherwise, -1.
        /// </summary>
        public int VendorItemIndex { get; }
        [JsonConstructor]
        internal InventoryItemPreviewBlockDerivedItemCategoryItem(uint? itemHash, string itemName, string itemDetail, string itemDescription, string iconPath,
            int vendorItemIndex)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            ItemName = ItemName;
            ItemDetail = itemDetail;
            ItemDescription = itemDescription;
            IconPath = iconPath;
            VendorItemIndex = vendorItemIndex;
        }

        public bool DeepEquals(InventoryItemPreviewBlockDerivedItemCategoryItem other)
        {
            return other != null &&
                   Item.DeepEquals(other.Item) &&
                   ItemName == other.ItemName &&
                   ItemDetail == other.ItemDetail &&
                   ItemDescription == other.ItemDescription &&
                   IconPath == other.IconPath &&
                   VendorItemIndex == other.VendorItemIndex;
        }
    }
}
