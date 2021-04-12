using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed  record SingleComponentResponseOfDestinyCharacterRecordsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyCharacterRecordsComponent Data { get; init; }
    }
}