using DotNetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

/// <summary>
///     Information about a single inventory bucket in a vendor flyout UI and how it is shown.
/// </summary>
public sealed record DestinyVendorInventoryFlyoutBucketDefinition
    : IDeepEquatable<DestinyVendorInventoryFlyoutBucketDefinition>
{
    /// <summary>
    ///     If true, the inventory bucket should be able to be collapsed visually.
    /// </summary>
    [JsonPropertyName("collapsible")]
    public bool Collapsible { get; init; }

    /// <summary>
    ///     The methodology to use for sorting items from the flyout.
    /// </summary>
    [JsonPropertyName("sortItemsBy")]
    public DestinyItemSortType SortItemsBy { get; init; }

    /// <summary>
    ///     The inventory bucket whose contents should be shown.
    /// </summary>
    [JsonPropertyName("inventoryBucketHash")]
    public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; init; } =
        DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;

    public bool DeepEquals(DestinyVendorInventoryFlyoutBucketDefinition other)
    {
        return other != null
            && Collapsible == other.Collapsible
            && SortItemsBy == other.SortItemsBy
            && InventoryBucket.DeepEquals(other.InventoryBucket);
    }
}
