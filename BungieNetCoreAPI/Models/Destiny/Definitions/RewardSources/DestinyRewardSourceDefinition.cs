using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.RewardSources
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyRewardSourceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyRewardSourceDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardSourceDefinition>
    {
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

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
