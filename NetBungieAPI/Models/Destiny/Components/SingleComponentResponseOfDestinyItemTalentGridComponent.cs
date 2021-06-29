using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemTalentGridComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemTalentGridComponent Data { get; init; }
    }
}