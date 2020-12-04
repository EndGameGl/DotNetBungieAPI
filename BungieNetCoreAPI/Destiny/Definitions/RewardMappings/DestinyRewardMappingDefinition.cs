using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardMappings
{
    /// <summary>
    /// Empty atm
    /// </summary>

    [DestinyDefinition("DestinyRewardMappingDefinition")]
    public class DestinyRewardMappingDefinition : DestinyDefinition
    {
        public uint MappingHash { get; }
        public int MappingIndex { get; }
        public bool IsGlobal { get; }
        [JsonConstructor]
        private DestinyRewardMappingDefinition(uint mappingHash, int mappingIndex, bool isGlobal, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            MappingHash = mappingHash;
            MappingIndex = mappingIndex;
            IsGlobal = IsGlobal;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
