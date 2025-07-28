namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyCollectiblesComponent
{
    [Destiny2Definition<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>("Destiny.Definitions.Collectibles.DestinyCollectibleDefinition")]
    [JsonPropertyName("collectibles")]
    public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent>? Collectibles { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection categories.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public uint CollectionCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection Badges.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public uint CollectionBadgesRootNodeHash { get; set; }
}
