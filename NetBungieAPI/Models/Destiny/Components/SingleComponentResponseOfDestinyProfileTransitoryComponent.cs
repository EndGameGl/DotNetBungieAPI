using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileTransitoryComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyProfileTransitoryComponent Data { get; init; }
    }
}