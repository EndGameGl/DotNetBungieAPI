using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

public sealed class DestinyVendorBaseComponent
{

    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; init; }

    [JsonPropertyName("nextRefreshDate")]
    public DateTime NextRefreshDate { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }
}
