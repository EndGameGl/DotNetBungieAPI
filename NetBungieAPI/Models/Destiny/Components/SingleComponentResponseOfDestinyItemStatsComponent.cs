using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemStatsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemStatsComponent Data { get; init; }
    }
}