namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Aggregations of multiple progressions.
/// <para />
///     These are used to apply rewards to multiple progressions at once. They can sometimes have human readable data as well, but only extremely sporadically.
/// </summary>
public class DestinyProgressionMappingDefinition
{
    /// <summary>
    ///     Infrequently defined in practice. Defer to the individual progressions' display properties.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public object DisplayProperties { get; set; }

    /// <summary>
    ///     The localized unit of measurement for progression across the progressions defined in this mapping. Unfortunately, this is very infrequently defined. Defer to the individual progressions' display units.
    /// </summary>
    [JsonPropertyName("displayUnits")]
    public string DisplayUnits { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
