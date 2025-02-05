﻿using DotNetBungieAPI.Models.Destiny.Definitions.VendorGroups;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Vendors;

/// <summary>
///     Represents a specific group of vendors that can be rendered in the recommended order.
///     <para />
///     How do we figure out this order? It's a long story, and will likely get more complicated over time.
/// </summary>
public sealed record DestinyVendorGroup
{
    [JsonPropertyName("vendorGroupHash")]
    public DefinitionHashPointer<DestinyVendorGroupDefinition> VendorGroup { get; init; } =
        DefinitionHashPointer<DestinyVendorGroupDefinition>.Empty;

    /// <summary>
    ///     The ordered list of vendors within a particular group.
    /// </summary>
    [JsonPropertyName("vendorHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyVendorDefinition>
    > Vendors { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>>.Empty;
}
