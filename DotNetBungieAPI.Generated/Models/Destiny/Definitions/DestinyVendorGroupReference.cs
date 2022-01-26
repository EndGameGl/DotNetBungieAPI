namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyVendorGroupReference : IDeepEquatable<DestinyVendorGroupReference>
{
    /// <summary>
    ///     The DestinyVendorGroupDefinition to which this Vendor can belong.
    /// </summary>
    [JsonPropertyName("vendorGroupHash")]
    public uint VendorGroupHash { get; set; }

    public bool DeepEquals(DestinyVendorGroupReference? other)
    {
        return other is not null &&
               VendorGroupHash == other.VendorGroupHash;
    }
}