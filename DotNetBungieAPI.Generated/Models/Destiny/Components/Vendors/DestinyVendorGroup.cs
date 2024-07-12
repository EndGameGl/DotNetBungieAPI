namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

/// <summary>
///     Represents a specific group of vendors that can be rendered in the recommended order.
/// <para />
///     How do we figure out this order? It's a long story, and will likely get more complicated over time.
/// </summary>
public class DestinyVendorGroup
{
    [Destiny2Definition<Destiny.Definitions.DestinyVendorGroupDefinition>("Destiny.Definitions.DestinyVendorGroupDefinition")]
    [JsonPropertyName("vendorGroupHash")]
    public uint? VendorGroupHash { get; set; }

    /// <summary>
    ///     The ordered list of vendors within a particular group.
    /// </summary>
    [Destiny2DefinitionList<Destiny.Definitions.DestinyVendorDefinition>("Destiny.Definitions.DestinyVendorDefinition")]
    [JsonPropertyName("vendorHashes")]
    public List<uint> VendorHashes { get; set; }
}
