namespace DotNetBungieAPI.Models.Destiny.Components.Collectibles;

public sealed class DestinyCollectiblesComponent
{
    [JsonPropertyName("collectibles")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>, Destiny.Components.Collectibles.DestinyCollectibleComponent>? Collectibles { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection categories.
    /// </summary>
    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CollectionCategoriesRootNodeHash { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection Badges.
    /// </summary>
    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CollectionBadgesRootNodeHash { get; init; }
}
