namespace DotNetBungieAPI.Models.Destiny.Definitions.Presentation;

public sealed class DestinyPresentationNodeCollectibleChildEntry
{
    [JsonPropertyName("collectibleHash")]
    public DefinitionHashPointer<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition> CollectibleHash { get; init; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; init; }
}
