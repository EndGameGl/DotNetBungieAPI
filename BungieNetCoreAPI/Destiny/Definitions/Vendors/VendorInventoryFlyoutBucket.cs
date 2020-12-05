using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInventoryFlyoutBucket
    {
        public bool Collapsible { get; }
        public ItemSortType SortItemsBy { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; }

        [JsonConstructor]
        private VendorInventoryFlyoutBucket(bool collapsible, ItemSortType sortItemsBy, uint inventoryBucketHash)
        {
            Collapsible = collapsible;
            SortItemsBy = sortItemsBy;
            InventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(inventoryBucketHash, "DestinyInventoryBucketDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
