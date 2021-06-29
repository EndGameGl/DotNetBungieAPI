using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileRecordsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyProfileRecordsComponent Data { get; init; }
    }
}