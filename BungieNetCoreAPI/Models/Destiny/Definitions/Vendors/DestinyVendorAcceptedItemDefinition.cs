using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorAcceptedItemDefinition : IDeepEquatable<DestinyVendorAcceptedItemDefinition>
    {
        [JsonPropertyName("acceptedInventoryBucketHash")]
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> AcceptedInventoryBucket { get; init; } = DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;
        [JsonPropertyName("destinationInventoryBucketHash")]
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> DestinationInventoryBucket { get; init; } = DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;

        public bool DeepEquals(DestinyVendorAcceptedItemDefinition other)
        {
            return other != null &&
                   AcceptedInventoryBucket.DeepEquals(other.AcceptedInventoryBucket) &&
                   DestinationInventoryBucket.DeepEquals(other.DestinationInventoryBucket);
        }
    }
}
