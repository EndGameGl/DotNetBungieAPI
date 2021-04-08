using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.MedalTiers
{
    [DestinyDefinition(DefinitionsEnum.DestinyMedalTierDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyMedalTierDefinition : IDestinyDefinition, IDeepEquatable<DestinyMedalTierDefinition>
    {
        public int Order { get; init; }
        public string TierName { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyMedalTierDefinition(int order, string tierName, bool blacklisted, uint hash, int index, bool redacted)
        {
            Order = order;
            TierName = tierName;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyMedalTierDefinition other)
        {
            return other != null &&
                   Order == other.Order &&
                   TierName == other.TierName &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
