namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Basic identifying data about the bubble. Combine with DestinyDestinationBubbleSettingDefinition - see DestinyDestinationDefinition.bubbleSettings for more information.
/// </summary>
public sealed class DestinyBubbleDefinition
{
    /// <summary>
    ///     The identifier for the bubble: only guaranteed to be unique within the Destination.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The display properties of this bubble, so you don't have to look them up in a separate list anymore.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }
}
