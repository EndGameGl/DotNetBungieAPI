using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Milestones;

public sealed record DestinyPublicMilestoneVendor
{
    /// <summary>
    ///     The hash identifier of the Vendor related to this Milestone. You can show useful things from this, such as thier
    ///     Faction icon or whatever you might care about.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    /// <summary>
    ///     If this vendor is featuring a specific item for this event, this will be the hash identifier of that item.
    /// </summary>
    [JsonPropertyName("previewItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> PreviewItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
}