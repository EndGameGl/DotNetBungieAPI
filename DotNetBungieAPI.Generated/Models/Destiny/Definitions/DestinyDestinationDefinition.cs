namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     On to one of the more confusing subjects of the API. What is a Destination, and what is the relationship between it, Activities, Locations, and Places?
/// <para />
///     A "Destination" is a specific region/city/area of a larger "Place". For instance, a Place might be Earth where a Destination might be Bellevue, Washington. (Please, pick a more interesting destination if you come to visit Earth).
/// </summary>
public class DestinyDestinationDefinition : IDestinyDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     The place that "owns" this Destination. Use this hash to look up the DestinyPlaceDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyPlaceDefinition>("Destiny.Definitions.DestinyPlaceDefinition")]
    [JsonPropertyName("placeHash")]
    public uint PlaceHash { get; set; }

    /// <summary>
    ///     If this Destination has a default Free-Roam activity, this is the hash for that Activity. Use it to look up the DestinyActivityDefintion.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("defaultFreeroamActivityHash")]
    public uint DefaultFreeroamActivityHash { get; set; }

    /// <summary>
    ///     If the Destination has default Activity Graphs (i.e. "Map") that should be shown in the director, this is the list of those Graphs. At most, only one should be active at any given time for a Destination: these would represent, for example, different variants on a Map if the Destination is changing on a macro level based on game state.
    /// </summary>
    [JsonPropertyName("activityGraphEntries")]
    public Destiny.Definitions.DestinyActivityGraphListEntryDefinition[]? ActivityGraphEntries { get; set; }

    /// <summary>
    ///     A Destination may have many "Bubbles" zones with human readable properties.
    /// <para />
    ///     We don't get as much info as I'd like about them - I'd love to return info like where on the map they are located - but at least this gives you the name of those bubbles. bubbleSettings and bubbles both have the identical number of entries, and you should match up their indexes to provide matching bubble and bubbleSettings data.
    /// <para />
    ///     DEPRECATED - Just use bubbles, it now has this data.
    /// </summary>
    [JsonPropertyName("bubbleSettings")]
    public Destiny.Definitions.DestinyDestinationBubbleSettingDefinition[]? BubbleSettings { get; set; }

    /// <summary>
    ///     This provides the unique identifiers for every bubble in the destination (only guaranteed unique within the destination), and any intrinsic properties of the bubble.
    /// <para />
    ///     bubbleSettings and bubbles both have the identical number of entries, and you should match up their indexes to provide matching bubble and bubbleSettings data.
    /// </summary>
    [JsonPropertyName("bubbles")]
    public Destiny.Definitions.DestinyBubbleDefinition[]? Bubbles { get; set; }

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
