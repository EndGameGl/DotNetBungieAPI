using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyInventoryComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public DestinyInventoryComponent Data { get; init; }
    }
}
