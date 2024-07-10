using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Destinations;

/// <summary>
///     Basic identifying data about the bubble. Combine with DestinyDestinationBubbleSettingDefinition - see
///     DestinyDestinationDefinition.bubbleSettings for more information.
/// </summary>
public sealed record DestinyBubbleDefinition : IDeepEquatable<DestinyBubbleDefinition>
{
    /// <summary>
    ///     The display properties of this bubble, so you don't have to look them up in a separate list anymore.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The identifier for the bubble: only guaranteed to be unique within the Destination.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    public bool DeepEquals(DestinyBubbleDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Hash == other.Hash;
    }
}
