using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardMappings
{
    /// <summary>
    /// Empty atm
    /// </summary>

    [DestinyDefinition(DefinitionsEnum.DestinyRewardMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyRewardMappingDefinition : IDestinyDefinition
    {
        public uint MappingHash { get; }
        public int MappingIndex { get; }
        public bool IsGlobal { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyRewardMappingDefinition(uint mappingHash, int mappingIndex, bool isGlobal, bool blacklisted, uint hash, int index, bool redacted)
        {
            MappingHash = mappingHash;
            MappingIndex = mappingIndex;
            IsGlobal = IsGlobal;
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
