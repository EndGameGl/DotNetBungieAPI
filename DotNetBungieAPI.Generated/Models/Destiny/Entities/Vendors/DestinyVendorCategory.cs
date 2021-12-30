using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Vendors;

public sealed class DestinyVendorCategory
{

    [JsonPropertyName("displayCategoryIndex")]
    public int DisplayCategoryIndex { get; init; }

    [JsonPropertyName("itemIndexes")]
    public List<int> ItemIndexes { get; init; }
}
