namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyProfileCollectiblesComponent
{
    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// </summary>
    [JsonPropertyName("recentCollectibleHashes")]
    public List<uint> RecentCollectibleHashes { get; set; }

    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// <para />
    ///     The game client itself actually controls this data, so I personally question whether anyone will get much use out of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
    /// </summary>
    [JsonPropertyName("newnessFlaggedCollectibleHashes")]
    public List<uint> NewnessFlaggedCollectibleHashes { get; set; }

    [JsonPropertyName("collectibles")]
    public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection categories.
    /// </summary>
    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public uint CollectionCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection Badges.
    /// </summary>
    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public uint CollectionBadgesRootNodeHash { get; set; }
}
