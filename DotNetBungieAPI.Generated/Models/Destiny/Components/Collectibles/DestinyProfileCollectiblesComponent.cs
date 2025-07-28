namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyProfileCollectiblesComponent
{
    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>("Destiny.Definitions.Collectibles.DestinyCollectibleDefinition")]
    [JsonPropertyName("recentCollectibleHashes")]
    public uint[]? RecentCollectibleHashes { get; set; }

    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// <para />
    ///     The game client itself actually controls this data, so I personally question whether anyone will get much use out of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Collectibles.DestinyCollectibleDefinition>("Destiny.Definitions.Collectibles.DestinyCollectibleDefinition")]
    [JsonPropertyName("newnessFlaggedCollectibleHashes")]
    public uint[]? NewnessFlaggedCollectibleHashes { get; set; }

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
