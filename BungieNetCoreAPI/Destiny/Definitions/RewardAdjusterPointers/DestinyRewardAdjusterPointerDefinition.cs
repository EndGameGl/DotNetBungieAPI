using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.RewardAdjusterPointers
{
    [DestinyDefinition(DefinitionsEnum.DestinyRewardAdjusterPointerDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyRewardAdjusterPointerDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardAdjusterPointerDefinition>
    {
        public int AdjusterType { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRewardAdjusterPointerDefinition(int adjusterType, bool blacklisted, uint hash, int index, bool redacted)
        {
            AdjusterType = adjusterType;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyRewardAdjusterPointerDefinition other)
        {
            return other != null &&
                   AdjusterType == other.AdjusterType &&
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
