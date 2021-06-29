using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyMetricsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyMetricsComponent Data { get; init; }
    }
}