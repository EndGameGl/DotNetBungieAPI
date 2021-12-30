using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorGroupReference
{

    [JsonPropertyName("vendorGroupHash")]
    public uint VendorGroupHash { get; init; }
}
