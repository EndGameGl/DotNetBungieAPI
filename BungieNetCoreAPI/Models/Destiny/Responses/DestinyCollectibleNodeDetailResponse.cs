using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyCollectibleNodeDetailResponse
    {
        [JsonPropertyName("collectibles")]
        public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; init; }
        [JsonPropertyName("collectibleItemComponents")]
        public DestinyItemComponentSetOfuint32 CollectibleItemComponents { get; init; }
    }
}