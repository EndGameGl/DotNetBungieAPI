using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyKiosksComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyKiosksComponent Data { get; init; }
    }
}
