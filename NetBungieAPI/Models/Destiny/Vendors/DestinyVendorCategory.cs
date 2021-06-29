using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Vendors
{
    /// <summary>
    ///     Information about the category and items currently sold in that category.
    /// </summary>
    public sealed record DestinyVendorCategory
    {
        /// <summary>
        ///     An index into the DestinyVendorDefinition.displayCategories property, so you can grab the display data for this
        ///     category.
        /// </summary>
        [JsonPropertyName("displayCategoryIndex")]
        public int DisplayCategoryIndex { get; init; }

        /// <summary>
        ///     An ordered list of indexes into items being sold in this category (DestinyVendorDefinition.itemList) which will
        ///     contain more information about the items being sold themselves. Can also be used to index into
        ///     DestinyVendorSaleItemComponent data, if you asked for that data to be returned.
        /// </summary>
        [JsonPropertyName("itemIndexes")]
        public ReadOnlyCollection<int> ItemIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
    }
}