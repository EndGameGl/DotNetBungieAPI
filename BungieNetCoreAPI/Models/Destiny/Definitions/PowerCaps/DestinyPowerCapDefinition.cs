using NetBungieAPI.Attributes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PowerCaps
{
    /// <summary>
    /// Defines a 'power cap' (limit) for gear items, based on the rarity tier and season of release.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPowerCapDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyPowerCapDefinition : IDestinyDefinition, IDeepEquatable<DestinyPowerCapDefinition>
    {
        [JsonPropertyName("powerCap")]
        public int PowerCap { get; init; }
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

        public bool DeepEquals(DestinyPowerCapDefinition other)
        {
            return other != null &&
                   PowerCap == other.PowerCap &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
