using NetBungieAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorInventoryFlyoutBucket : IDeepEquatable<VendorInventoryFlyoutBucket>
    {
        public bool Collapsible { get; init; }
        public ItemSortType SortItemsBy { get; init; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; init; }

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
