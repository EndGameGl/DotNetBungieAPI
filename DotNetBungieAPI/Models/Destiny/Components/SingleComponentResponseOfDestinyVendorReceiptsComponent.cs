using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorReceiptsComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorReceiptsComponent Data { get; init; }
    }
}