using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorGroupComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorGroupComponent Data { get; init; }
    }
}