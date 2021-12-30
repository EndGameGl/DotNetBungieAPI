using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public sealed class DestinyProfileCollectiblesComponent
{

    [JsonPropertyName("recentCollectibleHashes")]
    public List<uint> RecentCollectibleHashes { get; init; }

    [JsonPropertyName("newnessFlaggedCollectibleHashes")]
    public List<uint> NewnessFlaggedCollectibleHashes { get; init; }

    [JsonPropertyName("collectibles")]
    public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; init; }

    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public uint CollectionCategoriesRootNodeHash { get; init; }

    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public uint CollectionBadgesRootNodeHash { get; init; }
}
