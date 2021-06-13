using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileProgressionComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyProfileProgressionComponent Data { get; init; }
    }
}
