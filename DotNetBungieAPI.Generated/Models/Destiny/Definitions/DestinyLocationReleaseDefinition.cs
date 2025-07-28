namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
/// </summary>
public class DestinyLocationReleaseDefinition
{
    /// <summary>
    ///     Sadly, these don't appear to be populated anymore (ever?)
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; set; }

    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; set; }

    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; set; }

    /// <summary>
    ///     If we had map information, this spawnPoint would be interesting. But sadly, we don't have that info.
    /// </summary>
    [JsonPropertyName("spawnPoint")]
    public uint SpawnPoint { get; set; }

    /// <summary>
    ///     The Destination being pointed to by this location.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyDestinationDefinition>("Destiny.Definitions.DestinyDestinationDefinition")]
    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; set; }

    /// <summary>
    ///     The Activity being pointed to by this location.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     The Activity Graph being pointed to by this location.
    /// </summary>
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    /// <summary>
    ///     The Activity Graph Node being pointed to by this location. (Remember that Activity Graph Node hashes are only unique within an Activity Graph: so use the combination to find the node being spoken of)
    /// </summary>
    [JsonPropertyName("activityGraphNodeHash")]
    public uint ActivityGraphNodeHash { get; set; }

    /// <summary>
    ///     The Activity Bubble within the Destination. Look this up in the DestinyDestinationDefinition's bubbles and bubbleSettings properties.
    /// </summary>
    [JsonPropertyName("activityBubbleName")]
    public uint ActivityBubbleName { get; set; }

    /// <summary>
    ///     If we had map information, this would tell us something cool about the path this location wants you to take. I wish we had map information.
    /// </summary>
    [JsonPropertyName("activityPathBundle")]
    public uint ActivityPathBundle { get; set; }

    /// <summary>
    ///     If we had map information, this would tell us about path information related to destination on the map. Sad. Maybe you can do something cool with it. Go to town man.
    /// </summary>
    [JsonPropertyName("activityPathDestination")]
    public uint ActivityPathDestination { get; set; }

    /// <summary>
    ///     The type of Nav Point that this represents. See the enumeration for more info.
    /// </summary>
    [JsonPropertyName("navPointType")]
    public Destiny.DestinyActivityNavPointType NavPointType { get; set; }

    /// <summary>
    ///     Looks like it should be the position on the map, but sadly it does not look populated... yet?
    /// </summary>
    [JsonPropertyName("worldPosition")]
    public int[]? WorldPosition { get; set; }
}
