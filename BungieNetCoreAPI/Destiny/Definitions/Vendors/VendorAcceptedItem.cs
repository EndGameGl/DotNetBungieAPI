using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorAcceptedItem : IDeepEquatable<VendorAcceptedItem>
    {
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> AcceptedInventoryBucket { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> DestinationInventoryBucket { get; }

        [JsonConstructor]
        internal VendorAcceptedItem(uint acceptedInventoryBucketHash, uint destinationInventoryBucketHash)
        {
            AcceptedInventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(acceptedInventoryBucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            DestinationInventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(destinationInventoryBucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
        }

        public bool DeepEquals(VendorAcceptedItem other)
        {
            return other != null &&
                   AcceptedInventoryBucket.DeepEquals(other.AcceptedInventoryBucket) &&
                   DestinationInventoryBucket.DeepEquals(other.DestinationInventoryBucket);
        }
    }
}
