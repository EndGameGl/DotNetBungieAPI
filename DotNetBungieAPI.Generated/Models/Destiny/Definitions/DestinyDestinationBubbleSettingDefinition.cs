namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Human readable data about the bubble. Combine with DestinyBubbleDefinition - see DestinyDestinationDefinition.bubbleSettings for more information.
/// <para />
///     DEPRECATED - Just use bubbles.
/// </summary>
public class DestinyDestinationBubbleSettingDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }
}
