namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyVendorGroupReference
{
    /// <summary>
    ///     The DestinyVendorGroupDefinition to which this Vendor can belong.
    /// </summary>
    [JsonPropertyName("vendorGroupHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorGroupDefinition> VendorGroupHash { get; init; }
}
