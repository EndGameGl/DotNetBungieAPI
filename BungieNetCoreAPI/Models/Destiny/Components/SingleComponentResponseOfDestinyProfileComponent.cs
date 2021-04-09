using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyProfileComponent Data { get; init; }
    }
}
