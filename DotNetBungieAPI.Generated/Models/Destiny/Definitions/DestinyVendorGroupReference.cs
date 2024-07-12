namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyVendorGroupReference
{
    /// <summary>
    ///     The DestinyVendorGroupDefinition to which this Vendor can belong.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyVendorGroupDefinition>("Destiny.Definitions.DestinyVendorGroupDefinition")]
    [JsonPropertyName("vendorGroupHash")]
    public uint? VendorGroupHash { get; set; }
}
