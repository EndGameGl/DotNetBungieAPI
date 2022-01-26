namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Human readable data about the bubble. Combine with DestinyBubbleDefinition - see DestinyDestinationDefinition.bubbleSettings for more information.
/// <para />
///     DEPRECATED - Just use bubbles.
/// </summary>
public class DestinyDestinationBubbleSettingDefinition : IDeepEquatable<DestinyDestinationBubbleSettingDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    public bool DeepEquals(DestinyDestinationBubbleSettingDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null);
    }
}