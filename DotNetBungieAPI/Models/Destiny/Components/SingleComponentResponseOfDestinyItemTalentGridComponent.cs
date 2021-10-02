using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemTalentGridComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemTalentGridComponent Data { get; init; }
    }
}