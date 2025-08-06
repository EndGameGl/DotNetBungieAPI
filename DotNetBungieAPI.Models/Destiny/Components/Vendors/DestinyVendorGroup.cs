namespace DotNetBungieAPI.Models.Destiny.Components.Vendors;

/// <summary>
///     Represents a specific group of vendors that can be rendered in the recommended order.
/// <para />
///     How do we figure out this order? It's a long story, and will likely get more complicated over time.
/// </summary>
public sealed class DestinyVendorGroup
{
    [JsonPropertyName("vendorGroupHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorGroupDefinition> VendorGroupHash { get; init; }

    /// <summary>
    ///     The ordered list of vendors within a particular group.
    /// </summary>
    [JsonPropertyName("vendorHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorDefinition>[]? VendorHashes { get; init; }
}
