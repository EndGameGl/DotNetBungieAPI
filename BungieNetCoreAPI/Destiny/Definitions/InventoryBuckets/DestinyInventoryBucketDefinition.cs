using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets
{
    public class DestinyInventoryBucketDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int BucketOrder { get; }
        public int Category { get; }
        public bool Enabled { get; }
        public bool FirstInFirstOut { get; }
        public bool HasTransferDestination { get; }
        public int ItemCount { get; }
        public int Location { get; }
        public int Scope { get; }

        [JsonConstructor]
        private DestinyInventoryBucketDefinition(DestinyDefinitionDisplayProperties displayProperties, int bucketOrder, int category, bool enabled, bool fifo, bool hasTransferDestination,
            int itemCount, int location, int scope, bool blacklisted, uint hash, int index, bool redacted)
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
