using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorInventoryFlyoutBucketDefinition : IDeepEquatable<DestinyVendorInventoryFlyoutBucketDefinition>
    {
        [JsonPropertyName("collapsible")]
        public bool Collapsible { get; init; }
        [JsonPropertyName("sortItemsBy")]
        public DestinyItemSortType SortItemsBy { get; init; }
        [JsonPropertyName("inventoryBucketHash")]
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; init; } = DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;

        public bool DeepEquals(DestinyVendorInventoryFlyoutBucketDefinition other)
        {
            return other != null &&
                   Collapsible == other.Collapsible &&
                   SortItemsBy == other.SortItemsBy &&
                   InventoryBucket.DeepEquals(other.InventoryBucket);
        }
    }
}
