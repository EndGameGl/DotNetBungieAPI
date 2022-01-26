namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Information about a single inventory bucket in a vendor flyout UI and how it is shown.
/// </summary>
public class DestinyVendorInventoryFlyoutBucketDefinition : IDeepEquatable<DestinyVendorInventoryFlyoutBucketDefinition>
{
    /// <summary>
    ///     If true, the inventory bucket should be able to be collapsed visually.
    /// </summary>
    [JsonPropertyName("collapsible")]
    public bool Collapsible { get; set; }

    /// <summary>
    ///     The inventory bucket whose contents should be shown.
    /// </summary>
    [JsonPropertyName("inventoryBucketHash")]
    public uint InventoryBucketHash { get; set; }

    /// <summary>
    ///     The methodology to use for sorting items from the flyout.
    /// </summary>
    [JsonPropertyName("sortItemsBy")]
    public Destiny.DestinyItemSortType SortItemsBy { get; set; }

    public bool DeepEquals(DestinyVendorInventoryFlyoutBucketDefinition? other)
    {
        return other is not null &&
               Collapsible == other.Collapsible &&
               InventoryBucketHash == other.InventoryBucketHash &&
               SortItemsBy == other.SortItemsBy;
    }
}