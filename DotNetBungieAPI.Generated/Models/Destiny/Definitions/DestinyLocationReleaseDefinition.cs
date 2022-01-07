using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A specific "spot" referred to by a location. Only one of these can be active at a time for a given Location.
/// </summary>
public sealed class DestinyLocationReleaseDefinition
{

    /// <summary>
    ///     Sadly, these don't appear to be populated anymore (ever?)
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; init; }

    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; init; }

    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; init; }

    /// <summary>
    ///     If we had map information, this spawnPoint would be interesting. But sadly, we don't have that info.
    /// </summary>
    [JsonPropertyName("spawnPoint")]
    public uint SpawnPoint { get; init; }

    /// <summary>
    ///     The Destination being pointed to by this location.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; init; } // DestinyDestinationDefinition

    /// <summary>
    ///     The Activity being pointed to by this location.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; } // DestinyActivityDefinition

    /// <summary>
    ///     The Activity Graph being pointed to by this location.
    /// </summary>
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; init; }

    /// <summary>
    ///     The Activity Graph Node being pointed to by this location. (Remember that Activity Graph Node hashes are only unique within an Activity Graph: so use the combination to find the node being spoken of)
    /// </summary>
    [JsonPropertyName("activityGraphNodeHash")]
    public uint ActivityGraphNodeHash { get; init; }

    /// <summary>
    ///     The Activity Bubble within the Destination. Look this up in the DestinyDestinationDefinition's bubbles and bubbleSettings properties.
    /// </summary>
    [JsonPropertyName("activityBubbleName")]
    public uint ActivityBubbleName { get; init; }

    /// <summary>
    ///     If we had map information, this would tell us something cool about the path this location wants you to take. I wish we had map information.
    /// </summary>
    [JsonPropertyName("activityPathBundle")]
    public uint ActivityPathBundle { get; init; }

    /// <summary>
    ///     If we had map information, this would tell us about path information related to destination on the map. Sad. Maybe you can do something cool with it. Go to town man.
    /// </summary>
    [JsonPropertyName("activityPathDestination")]
    public uint ActivityPathDestination { get; init; }

    /// <summary>
    ///     The type of Nav Point that this represents. See the enumeration for more info.
    /// </summary>
    [JsonPropertyName("navPointType")]
    public Destiny.DestinyActivityNavPointType NavPointType { get; init; }

    /// <summary>
    ///     Looks like it should be the position on the map, but sadly it does not look populated... yet?
    /// </summary>
    [JsonPropertyName("worldPosition")]
    public List<int> WorldPosition { get; init; }
}
