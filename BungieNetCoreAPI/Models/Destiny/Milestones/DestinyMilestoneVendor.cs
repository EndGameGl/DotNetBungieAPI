using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneVendor
    {
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } = DefinitionHashPointer<DestinyVendorDefinition>.Empty;
        [JsonPropertyName("previewItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PreviewItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
    }
}
