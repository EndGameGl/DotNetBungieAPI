namespace DotNetBungieAPI.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeChildEntry
{
    [JsonPropertyName("presentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> PresentationNodeHash { get; init; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }
}
