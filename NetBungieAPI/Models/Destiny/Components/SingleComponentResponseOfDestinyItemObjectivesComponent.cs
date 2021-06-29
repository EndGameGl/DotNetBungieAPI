using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemObjectivesComponent Data { get; init; }
    }
}