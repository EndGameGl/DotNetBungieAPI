using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemPlugObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemPlugObjectivesComponent Data { get; init; }
    }
}