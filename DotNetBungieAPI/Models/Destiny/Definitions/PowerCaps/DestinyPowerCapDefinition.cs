using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.PowerCaps
{
    /// <summary>
    ///     Defines a 'power cap' (limit) for gear items, based on the rarity tier and season of release.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPowerCapDefinition)]
    public sealed record DestinyPowerCapDefinition : IDestinyDefinition, IDeepEquatable<DestinyPowerCapDefinition>
    {
        /// <summary>
        ///     The raw value for a power cap.
        /// </summary>
        [JsonPropertyName("powerCap")]
        public int PowerCap { get; init; }

        public bool DeepEquals(DestinyPowerCapDefinition other)
        {
            return other != null &&
                   PowerCap == other.PowerCap &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyPowerCapDefinition;
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