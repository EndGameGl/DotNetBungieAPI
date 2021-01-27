using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PlatformBucketMappings
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyPlatformBucketMappingDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyPlatformBucketMappingDefinition : IDestinyDefinition
    {
        public int MembershipType { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyPlatformBucketMappingDefinition(int membershipType, uint bucketHash, bool blacklisted, uint hash, int index, bool redacted)
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
    }
}
