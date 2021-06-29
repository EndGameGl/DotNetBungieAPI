using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyPlugSetsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyPlugSetsComponent Data { get; init; }
    }
}