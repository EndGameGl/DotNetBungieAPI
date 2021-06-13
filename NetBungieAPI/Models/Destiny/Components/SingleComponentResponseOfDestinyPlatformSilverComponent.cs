using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyPlatformSilverComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyPlatformSilverComponent Data { get; init; }
    }
}
