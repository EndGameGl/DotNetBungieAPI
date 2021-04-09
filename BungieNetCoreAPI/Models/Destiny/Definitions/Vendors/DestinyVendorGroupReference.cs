using NetBungieAPI.Models.Destiny.Definitions.VendorGroups;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorGroupReference : IDeepEquatable<DestinyVendorGroupReference>
    {
        [JsonPropertyName("vendorGroupHash")]
        public DefinitionHashPointer<DestinyVendorGroupDefinition> Group { get; init; } = DefinitionHashPointer<DestinyVendorGroupDefinition>.Empty;

        public bool DeepEquals(DestinyVendorGroupReference other)
        {
            return other != null &&
                   Group.DeepEquals(other.Group);
        }
    }
}
