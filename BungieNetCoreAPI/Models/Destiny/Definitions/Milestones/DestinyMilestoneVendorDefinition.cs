using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneVendorDefinition : IDeepEquatable<DestinyMilestoneVendorDefinition>
    {
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } = DefinitionHashPointer<DestinyVendorDefinition>.Empty;

        public bool DeepEquals(DestinyMilestoneVendorDefinition other)
        {
            return other != null && Vendor.DeepEquals(other.Vendor);
        }
    }
}
