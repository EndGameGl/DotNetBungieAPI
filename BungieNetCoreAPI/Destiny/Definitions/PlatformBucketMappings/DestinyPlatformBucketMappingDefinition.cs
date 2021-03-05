using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PlatformBucketMappings
{
    [DestinyDefinition(DefinitionsEnum.DestinyPlatformBucketMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyPlatformBucketMappingDefinition : IDestinyDefinition, IDeepEquatable<DestinyPlatformBucketMappingDefinition>
    {
        public int MembershipType { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyPlatformBucketMappingDefinition(int membershipType, uint bucketHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            MembershipType = membershipType;
            Bucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyPlatformBucketMappingDefinition other)
        {
            return other != null &&
                   MembershipType == other.MembershipType &&
                   Bucket.DeepEquals(other.Bucket) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
