using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorComponent Data { get; init; }
    }
}