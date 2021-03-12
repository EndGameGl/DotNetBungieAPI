using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardSources
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyRewardSourceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyRewardSourceDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardSourceDefinition>
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRewardSourceDefinition(bool blacklisted, uint hash, int index, bool redacted)
        {
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyRewardSourceDefinition other)
        {
            return other != null &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
