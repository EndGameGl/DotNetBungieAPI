using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileCollectiblesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyProfileCollectiblesComponent Data { get; init; }
    }
}
