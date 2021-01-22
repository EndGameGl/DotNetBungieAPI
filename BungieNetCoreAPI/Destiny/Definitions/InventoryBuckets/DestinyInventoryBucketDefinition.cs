using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets
{
    [DestinyDefinition(name: "DestinyInventoryBucketDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyInventoryBucketDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int BucketOrder { get; }
        public BucketCategory Category { get; }
        public bool Enabled { get; }
        public bool FirstInFirstOut { get; }
        public bool HasTransferDestination { get; }
        public int ItemCount { get; }
        public BucketItemLocation Location { get; }
        public BucketScope Scope { get; }

        [JsonConstructor]
        private DestinyInventoryBucketDefinition(DestinyDefinitionDisplayProperties displayProperties, int bucketOrder, BucketCategory category, bool enabled, bool fifo, 
            bool hasTransferDestination, int itemCount, BucketItemLocation location, BucketScope scope, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
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
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
