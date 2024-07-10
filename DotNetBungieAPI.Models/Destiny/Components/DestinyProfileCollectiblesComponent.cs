using DotNetBungieAPI.Models.Destiny.Definitions.Collectibles;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyProfileCollectiblesComponent
{
    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// </summary>
    [JsonPropertyName("recentCollectibleHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyCollectibleDefinition>
    > RecentCollectibles { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyCollectibleDefinition>>.Empty;

    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    ///     <para />
    ///     The game client itself actually controls this data, so I personally question whether anyone will get much use out
    ///     of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
    /// </summary>
    [JsonPropertyName("newnessFlaggedCollectibleHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyCollectibleDefinition>
    > NewnessFlaggedCollectibles { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyCollectibleDefinition>>.Empty;

    [JsonPropertyName("collectibles")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinyCollectibleDefinition>,
        DestinyCollectibleComponent
    > Collectibles { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection categories.
    /// </summary>
    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    /// <summary>
    ///     The hash for the root presentation node definition of Collection Badges.
    /// </summary>
    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
}
