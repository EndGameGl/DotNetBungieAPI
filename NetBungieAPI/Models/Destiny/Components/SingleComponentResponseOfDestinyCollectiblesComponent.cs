using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyCollectiblesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyCollectiblesComponent Data { get; init; }
    }
}