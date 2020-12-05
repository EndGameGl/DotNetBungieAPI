using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorAcceptedItem
    {
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> AcceptedInventoryBucket { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> DestinationInventoryBucket { get; }

        [JsonConstructor]
        private VendorAcceptedItem(uint acceptedInventoryBucketHash, uint destinationInventoryBucketHash)
        {
            AcceptedInventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(acceptedInventoryBucketHash, "DestinyInventoryBucketDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            DestinationInventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(destinationInventoryBucketHash, "DestinyInventoryBucketDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
