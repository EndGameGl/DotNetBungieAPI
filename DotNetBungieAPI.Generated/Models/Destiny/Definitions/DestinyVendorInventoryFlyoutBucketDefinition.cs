using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorInventoryFlyoutBucketDefinition
{

    [JsonPropertyName("collapsible")]
    public bool Collapsible { get; init; }

    [JsonPropertyName("inventoryBucketHash")]
    public uint InventoryBucketHash { get; init; }

    [JsonPropertyName("sortItemsBy")]
    public Destiny.DestinyItemSortType SortItemsBy { get; init; }
}
