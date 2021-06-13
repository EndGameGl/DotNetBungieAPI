using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed  record SingleComponentResponseOfDestinyItemRenderComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyItemRenderComponent Data { get; init; }
    }
}