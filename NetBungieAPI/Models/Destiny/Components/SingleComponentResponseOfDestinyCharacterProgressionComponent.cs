using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyCharacterProgressionComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyCharacterProgressionComponent Data { get; init; }
    }
}