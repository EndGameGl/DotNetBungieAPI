using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.RewardAdjusterProgressionMaps
{
    [DestinyDefinition(DefinitionsEnum.DestinyRewardAdjusterProgressionMapDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyRewardAdjusterProgressionMapDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardAdjusterProgressionMapDefinition>
    {
        public bool IsAdditive { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRewardAdjusterProgressionMapDefinition(bool isAdditive, bool blacklisted, uint hash, int index, bool redacted)
        {
            IsAdditive = isAdditive;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyRewardAdjusterProgressionMapDefinition other)
        {
            return other != null &&
                   IsAdditive == other.IsAdditive &&
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
