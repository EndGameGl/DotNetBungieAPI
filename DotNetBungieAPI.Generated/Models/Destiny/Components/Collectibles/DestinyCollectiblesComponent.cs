using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public sealed class DestinyCollectiblesComponent
{

    [JsonPropertyName("collectibles")]
    public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; init; }

    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public uint CollectionCategoriesRootNodeHash { get; init; }

    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public uint CollectionBadgesRootNodeHash { get; init; }
}
