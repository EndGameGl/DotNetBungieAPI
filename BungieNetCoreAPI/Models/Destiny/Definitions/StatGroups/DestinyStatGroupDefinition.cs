using NetBungieAPI.Attributes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.StatGroups
{
    [DestinyDefinition(DefinitionsEnum.DestinyStatGroupDefinition)]
    public sealed record DestinyStatGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatGroupDefinition>
    {
        [JsonPropertyName("maximumValue")]
        public int MaximumValue { get; init; }
        [JsonPropertyName("uiPosition")]
        public int UiPosition { get; init; }
        [JsonPropertyName("scaledStats")]
        public ReadOnlyCollection<DestinyStatDisplayDefinition> ScaledStats { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyStatDisplayDefinition>();
        [JsonPropertyName("overrides")]
        public ReadOnlyDictionary<uint, DestinyStatOverrideDefinition> Overrides { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyStatOverrideDefinition>();
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
            return $"{Hash} {MaximumValue}";
        }

        public void MapValues()
        {
            foreach (var stat in ScaledStats)
            {
                stat.Stat.TryMapValue();
            }
            foreach (var value in Overrides.Values)
            {
                value.Stat.TryMapValue();
            }
        }

        public bool DeepEquals(DestinyStatGroupDefinition other)
        {
            return other != null &&
                   MaximumValue == other.MaximumValue &&
                   UiPosition == other.UiPosition &&
                   ScaledStats.DeepEqualsReadOnlyCollections(other.ScaledStats) &&
                   Overrides.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.Overrides) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
