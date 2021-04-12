using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public class SingleComponentResponseOfDestinyCharacterRenderComponent
    {
        [JsonPropertyName("data")]
        public DestinyCharacterRenderComponent Data { get; init; }
    }
}