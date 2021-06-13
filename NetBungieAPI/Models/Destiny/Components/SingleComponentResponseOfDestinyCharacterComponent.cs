using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyCharacterComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyCharacterComponent Data { get; init; }
    }
}
