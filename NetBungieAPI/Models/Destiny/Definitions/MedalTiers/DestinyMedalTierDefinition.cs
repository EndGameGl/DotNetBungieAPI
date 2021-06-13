using NetBungieAPI.Attributes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.MedalTiers
{
    [DestinyDefinition(DefinitionsEnum.DestinyMedalTierDefinition)]
    public sealed record DestinyMedalTierDefinition : IDestinyDefinition, IDeepEquatable<DestinyMedalTierDefinition>
    {
        [JsonPropertyName("order")]
        public int Order { get; init; }
        [JsonPropertyName("tierName")]
        public string TierName { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

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
