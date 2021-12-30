using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

public sealed class DestinyVendorGroup
{

    [JsonPropertyName("vendorGroupHash")]
    public uint VendorGroupHash { get; init; }

    [JsonPropertyName("vendorHashes")]
    public List<uint> VendorHashes { get; init; }
}
