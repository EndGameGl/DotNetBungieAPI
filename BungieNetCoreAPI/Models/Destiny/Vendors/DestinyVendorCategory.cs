using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Vendors
{
    public sealed record DestinyVendorCategory
    {
        [JsonPropertyName("categories")] 
        public int DisplayCategoryIndex { get; init; }

        [JsonPropertyName("categories")]
        public ReadOnlyCollection<int> ItemIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
    }
}