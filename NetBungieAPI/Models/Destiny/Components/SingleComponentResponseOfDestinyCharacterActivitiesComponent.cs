using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed  record SingleComponentResponseOfDestinyCharacterActivitiesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyCharacterActivitiesComponent Data { get; init; }
    }
}