using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PlatformBucketMappings
{
    [DestinyDefinition("DestinyPlatformBucketMappingDefinition")]
    public class DestinyPlatformBucketMappingDefinition : DestinyDefinition
    {
        public int MembershipType { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; }

        [JsonConstructor]
        private DestinyPlatformBucketMappingDefinition(int membershipType, uint bucketHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            MembershipType = membershipType;
            Bucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketHash, "DestinyInventoryBucketDefinition");
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
