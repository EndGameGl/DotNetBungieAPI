using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemInstanceComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemInstanceComponent Data { get; init; }
    }
}