namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeCollectibleChildEntry
{
    [Destiny2Definition<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>("Destiny.Definitions.Collectibles.DestinyCollectibleDefinition")]
    [JsonPropertyName("collectibleHash")]
    public uint? CollectibleHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint? NodeDisplayPriority { get; set; }
}
