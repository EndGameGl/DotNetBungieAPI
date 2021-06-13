using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyItemReusablePlugsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyItemReusablePlugsComponent Data { get; init; }
    }
}