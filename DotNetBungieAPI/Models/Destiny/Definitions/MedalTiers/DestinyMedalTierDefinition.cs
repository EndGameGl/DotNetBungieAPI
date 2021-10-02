using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.MedalTiers
{
    [DestinyDefinition(DefinitionsEnum.DestinyMedalTierDefinition)]
    public sealed record DestinyMedalTierDefinition : IDestinyDefinition, IDeepEquatable<DestinyMedalTierDefinition>
    {
        [JsonPropertyName("order")] public int Order { get; init; }

        [JsonPropertyName("tierName")] public string TierName { get; init; }

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

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyMedalTierDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")] public uint Hash { get; init; }

        [JsonPropertyName("index")] public int Index { get; init; }

        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public void SetPointerLocales(BungieLocales locale)
        {
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}