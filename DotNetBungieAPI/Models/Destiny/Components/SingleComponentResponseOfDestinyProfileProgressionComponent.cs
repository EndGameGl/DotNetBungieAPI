using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileProgressionComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyProfileProgressionComponent Data { get; init; }
    }
}