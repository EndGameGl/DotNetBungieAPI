using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// This is a reference to, and summary data for, a specific item that you can get as a result of Using or Acquiring some other Item (For example, this could be summary information for an Emote that you can get by opening an an Eververse Box)
    /// </summary>
    public sealed record DestinyDerivedItemDefinition : IDeepEquatable<DestinyDerivedItemDefinition>
    {
        /// <summary>
        /// DestinyInventoryItemDefinition of this derived item, if there is one. Sometimes we are given this information as a manual override, in which case there won't be an actual DestinyInventoryItemDefinition for what we display, but you can still show the strings from this object itself.
        /// </summary>
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        /// The name of the derived item.
        /// </summary>
        [JsonPropertyName("itemName")]
        public string ItemName { get; init; }

        /// <summary>
        /// Additional details about the derived item, in addition to the description.
        /// </summary>
        [JsonPropertyName("itemDetail")]
        public string ItemDetail { get; init; }

        /// <summary>
        /// A brief description of the item
        /// </summary>
        [JsonPropertyName("itemDescription")]
        public string ItemDescription { get; init; }

        /// <summary>
        /// An icon for the item.
        /// </summary>
        [JsonPropertyName("iconPath")]
        public string IconPath { get; init; }

        /// <summary>
        /// If the item was derived from a "Preview Vendor", this will be an index into the DestinyVendorDefinition's itemList property. Otherwise, -1.
        /// </summary>
        [JsonPropertyName("vendorItemIndex")]
        public int VendorItemIndex { get; init; }

        public bool DeepEquals(DestinyDerivedItemDefinition other)
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