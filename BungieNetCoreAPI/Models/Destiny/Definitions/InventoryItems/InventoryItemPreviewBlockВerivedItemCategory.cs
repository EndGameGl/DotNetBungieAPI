using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// A shortcut for the fact that some items have a "Preview Vendor" - See DestinyInventoryItemDefinition.preview.previewVendorHash - that is intended to be used to show what items you can get as a result of acquiring or using this item.
    /// <para/>
    /// A common example of this in Destiny 1 was Eververse "Boxes," which could have many possible items. This "Preview Vendor" is not a vendor you can actually see in the game, but it defines categories and sale items for all of the possible items you could get from the Box so that the game can show them to you. We summarize that info here so that you don't have to do that Vendor lookup and aggregation manually.
    /// </summary>
    public class InventoryItemPreviewBlockDerivedItemCategory : IDeepEquatable<InventoryItemPreviewBlockDerivedItemCategory>
    {
        public string CategoryDescription { get; init; }
        public ReadOnlyCollection<InventoryItemPreviewBlockDerivedItemCategoryItem> Items { get; init; }
        [JsonConstructor]
        internal InventoryItemPreviewBlockDerivedItemCategory(string categoryDescription, InventoryItemPreviewBlockDerivedItemCategoryItem[] items)
        {
            CategoryDescription = categoryDescription;
            Items = items.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemPreviewBlockDerivedItemCategory other)
        {
            return other != null &&
                CategoryDescription == other.CategoryDescription &&
                Items.DeepEqualsReadOnlyCollections(other.Items);
        }
    }
}
