using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardMappings
{
    /// <summary>
    /// Empty atm
    /// </summary>

    [DestinyDefinition(DefinitionsEnum.DestinyRewardMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyRewardMappingDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardMappingDefinition>
    {
        public uint MappingHash { get; }
        public int MappingIndex { get; }
        public bool IsGlobal { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        internal DestinyRewardMappingDefinition(uint mappingHash, int mappingIndex, bool isGlobal, bool blacklisted, uint hash, int index, bool redacted)
        {
            MappingHash = mappingHash;
            MappingIndex = mappingIndex;
            IsGlobal = isGlobal;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyRewardMappingDefinition other)
        {
            return other != null &&
                   MappingHash == other.MappingHash &&
                   MappingIndex == other.MappingIndex &&
                   IsGlobal == other.IsGlobal &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
