using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ProgressionMappings
{
    /// <summary>
    /// Aggregations of multiple progressions.
    /// <para/>
    /// These are used to apply rewards to multiple progressions at once. They can sometimes have human readable data as well, but only extremely sporadically.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionMappingDefinition)]
    public sealed record DestinyProgressionMappingDefinition : IDestinyDefinition,
        IDeepEquatable<DestinyProgressionMappingDefinition>
    {
        /// <summary>
        /// Infrequently defined in practice. Defer to the individual progressions' display properties.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        /// The localized unit of measurement for progression across the progressions defined in this mapping. Unfortunately, this is very infrequently defined. Defer to the individual progressions' display units.
        /// </summary>
        [JsonPropertyName("displayUnits")]
        public string DisplayUnits { get; init; }

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyProgressionMappingDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   DisplayUnits.Equals(other.DisplayUnits) &&
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