using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorGroupReference
{

    /// <summary>
    ///     The DestinyVendorGroupDefinition to which this Vendor can belong.
    /// </summary>
    [JsonPropertyName("vendorGroupHash")]
    public uint VendorGroupHash { get; init; }
}
