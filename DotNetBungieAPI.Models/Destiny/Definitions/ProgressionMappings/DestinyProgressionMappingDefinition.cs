using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ProgressionMappings;

/// <summary>
///     Aggregations of multiple progressions.
///     <para />
///     These are used to apply rewards to multiple progressions at once. They can sometimes have human readable data as
///     well, but only extremely sporadically.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyProgressionMappingDefinition)]
public sealed record DestinyProgressionMappingDefinition : IDestinyDefinition, IDisplayProperties, IDeepEquatable<DestinyProgressionMappingDefinition>
{
    /// <summary>
    ///     Infrequently defined in practice. Defer to the individual progressions' display properties.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The localized unit of measurement for progression across the progressions defined in this mapping. Unfortunately,
    ///     this is very infrequently defined. Defer to the individual progressions' display units.
    /// </summary>
    [JsonPropertyName("displayUnits")]
    public string DisplayUnits { get; init; }

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

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyProgressionMappingDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}