namespace DotNetBungieAPI.Models.Destiny.Components.Collectibles;

public sealed class DestinyProfileCollectiblesComponent
{
    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// </summary>
    [JsonPropertyName("recentCollectibleHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>[]? RecentCollectibleHashes { get; init; }

    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// <para />
    ///     The game client itself actually controls this data, so I personally question whether anyone will get much use out of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
    /// </summary>
    [JsonPropertyName("newnessFlaggedCollectibleHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>[]? NewnessFlaggedCollectibleHashes { get; init; }

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
