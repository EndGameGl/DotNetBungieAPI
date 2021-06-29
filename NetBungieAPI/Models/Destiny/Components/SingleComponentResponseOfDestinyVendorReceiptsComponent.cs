using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorReceiptsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorReceiptsComponent Data { get; init; }
    }
}