using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets
{
    /// <summary>
    /// An Inventory (be it Character or Profile level) is comprised of many Buckets. An example of a bucket is "Primary Weapons", where all of the primary weapons on a character are gathered together into a single visual element in the UI: a subset of the inventory that has a limited number of slots, and in this case also has an associated Equipment Slot for equipping an item in the bucket.
    /// <para/>
    /// Item definitions declare what their "default" bucket is (DestinyInventoryItemDefinition.inventory.bucketTypeHash), and Item instances will tell you which bucket they are currently residing in (DestinyItemComponent.bucketHash). You can use this information along with the DestinyInventoryBucketDefinition to show these items grouped by bucket.
    /// <para/>
    /// You cannot transfer an item to a bucket that is not its Default without going through a Vendor's "accepted items" (DestinyVendorDefinition.acceptedItems). This is how transfer functionality like the Vault is implemented, as a feature of a Vendor. See the vendor's acceptedItems property for more details.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyInventoryBucketDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyInventoryBucketDefinition : IDestinyDefinition, IDeepEquatable<DestinyInventoryBucketDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// Use this property to provide a quick-and-dirty recommended ordering for buckets in the UI. Most UIs will likely want to forsake this for something more custom and manual.
        /// </summary>
        public int BucketOrder { get; }
        /// <summary>
        /// An enum value for what items can be found in the bucket.
        /// </summary>
        public BucketCategory Category { get; }
        /// <summary>
        /// If True, this bucket is enabled. Disabled buckets may include buckets that were included for test purposes, or that were going to be used but then were abandoned but never removed from content *cough*.
        /// </summary>
        public bool Enabled { get; }
        /// <summary>
        /// if a FIFO bucket fills up, it will delete the oldest item from said bucket when a new item tries to be added to it. If this is FALSE, the bucket will not allow new items to be placed in it until room is made by the user manually deleting items from it. You can see an example of this with the Postmaster's bucket.
        /// </summary>
        public bool FirstInFirstOut { get; }
        /// <summary>
        /// If TRUE, there is at least one Vendor that can transfer items to/from this bucket. See the DestinyVendorDefinition's acceptedItems property for more information on how transferring works.
        /// </summary>
        public bool HasTransferDestination { get; }
        /// <summary>
        /// The maximum # of item "slots" in a bucket. A slot is a given combination of item + quantity.
        /// <para/>
        /// For instance, a Weapon will always take up a single slot, and always have a quantity of 1. But a material could take up only a single slot with hundreds of quantity.
        /// </summary>
        public int ItemCount { get; }
        /// <summary>
        /// Sometimes, inventory buckets represent conceptual "locations" in the game that might not be expected. This value indicates the conceptual location of the bucket, regardless of where it is actually contained on the character/account.
        /// </summary>
        public BucketItemLocation Location { get; }
        /// <summary>
        /// Where the bucket is found.
        /// </summary>
        public Scope Scope { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyInventoryBucketDefinition(DestinyDefinitionDisplayProperties displayProperties, int bucketOrder, BucketCategory category, bool enabled, bool fifo, 
            bool hasTransferDestination, int itemCount, BucketItemLocation location, Scope scope, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            BucketOrder = bucketOrder;
            Category = category;
            Enabled = enabled;
            FirstInFirstOut = fifo;
            HasTransferDestination = hasTransferDestination;
            ItemCount = itemCount;
            Location = location;
            Scope = scope;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyInventoryBucketDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   BucketOrder == other.BucketOrder &&
                   Category == other.Category &&
                   Enabled == other.Enabled &&
                   FirstInFirstOut == other.FirstInFirstOut &&
                   HasTransferDestination == other.HasTransferDestination &&
                   ItemCount == other.ItemCount &&
                   Location == other.Location &&
                   Scope == other.Scope &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
