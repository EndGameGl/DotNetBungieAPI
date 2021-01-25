using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using Unity;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorAcceptedItem
    {
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> AcceptedInventoryBucket { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> DestinationInventoryBucket { get; }

        [JsonConstructor]
        private VendorAcceptedItem(uint acceptedInventoryBucketHash, uint destinationInventoryBucketHash)
        {
            AcceptedInventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(acceptedInventoryBucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            DestinationInventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(destinationInventoryBucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
        }
    }
}
