﻿using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

/// <summary>
///     If the Milestone or a component has vendors whose inventories could/should be displayed that are relevant to it,
///     this will return the vendor in question.
///     <para />
///     It also contains information we need to determine whether that vendor is actually relevant at the moment, given the
///     user's current state.
/// </summary>
public sealed record DestinyMilestoneVendorDefinition
    : IDeepEquatable<DestinyMilestoneVendorDefinition>
{
    /// <summary>
    ///     The hash of the vendor whose wares should be shown as associated with the Milestone.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    public bool DeepEquals(DestinyMilestoneVendorDefinition other)
    {
        return other != null && Vendor.DeepEquals(other.Vendor);
    }
}
