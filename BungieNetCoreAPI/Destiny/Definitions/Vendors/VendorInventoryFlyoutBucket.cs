using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInventoryFlyoutBucket : IDeepEquatable<VendorInventoryFlyoutBucket>
    {
        public bool Collapsible { get; }
        public ItemSortType SortItemsBy { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; }

        [JsonConstructor]
        internal VendorInventoryFlyoutBucket(bool collapsible, ItemSortType sortItemsBy, uint inventoryBucketHash)
        {
            Collapsible = collapsible;
            SortItemsBy = sortItemsBy;
            InventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(inventoryBucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
        }

        public bool DeepEquals(VendorInventoryFlyoutBucket other)
        {
            return other != null &&
                   Collapsible == other.Collapsible &&
                   SortItemsBy == other.SortItemsBy &&
                   InventoryBucket.DeepEquals(other.InventoryBucket);
        }
    }
}
