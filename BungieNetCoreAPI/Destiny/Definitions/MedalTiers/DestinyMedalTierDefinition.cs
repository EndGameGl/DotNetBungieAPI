using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.MedalTiers
{
    [DestinyDefinition(DefinitionsEnum.DestinyMedalTierDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyMedalTierDefinition : IDestinyDefinition, IDeepEquatable<DestinyMedalTierDefinition>
    {
        public int Order { get; }
        public string TierName { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

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
