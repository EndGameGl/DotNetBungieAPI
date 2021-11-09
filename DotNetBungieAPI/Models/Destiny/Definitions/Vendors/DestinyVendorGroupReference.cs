using DotNetBungieAPI.Models.Destiny.Definitions.VendorGroups;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorGroupReference : IDeepEquatable<DestinyVendorGroupReference>
    {
        /// <summary>
        ///     The DestinyVendorGroupDefinition to which this Vendor can belong.
        /// </summary>
        [JsonPropertyName("vendorGroupHash")]
        public DefinitionHashPointer<DestinyVendorGroupDefinition> Group { get; init; } =
            DefinitionHashPointer<DestinyVendorGroupDefinition>.Empty;

        public bool DeepEquals(DestinyVendorGroupReference other)
        {
            return other != null &&
                   Group.DeepEquals(other.Group);
        }
    }
}