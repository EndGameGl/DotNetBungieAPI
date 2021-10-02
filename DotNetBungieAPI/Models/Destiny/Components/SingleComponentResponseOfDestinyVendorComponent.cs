using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record SingleComponentResponseOfDestinyVendorComponent : ComponentResponse
    {
        [JsonPropertyName("data")] public DestinyVendorComponent Data { get; init; }
    }
}