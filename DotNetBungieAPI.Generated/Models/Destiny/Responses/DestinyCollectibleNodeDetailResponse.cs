using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyCollectibleNodeDetailResponse
{

    [JsonPropertyName("collectibles")]
    public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; init; }

    [JsonPropertyName("collectibleItemComponents")]
    public DestinyItemComponentSetOfuint32 CollectibleItemComponents { get; init; }
}
