using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyProfileTransitoryComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyProfileTransitoryComponent Data { get; init; }
    }
}