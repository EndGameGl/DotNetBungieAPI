using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemPerksComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyItemPerksComponent Data { get; init; }
    }
}