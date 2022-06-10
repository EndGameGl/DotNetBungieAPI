namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyCollectiblesComponent
{
    [JsonPropertyName("collectibles")]
    public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection categories.
    /// </summary>
    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public uint? CollectionCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection Badges.
    /// </summary>
    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public uint? CollectionBadgesRootNodeHash { get; set; }
}
