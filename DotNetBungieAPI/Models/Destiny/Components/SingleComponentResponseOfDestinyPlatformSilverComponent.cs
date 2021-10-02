using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyPlatformSilverComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyPlatformSilverComponent Data { get; init; }
    }
}