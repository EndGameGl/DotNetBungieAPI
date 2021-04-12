using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.VendorGroups;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace NetBungieAPI.Models.Destiny.Vendors
{
    public sealed record DestinyVendorGroup
    {
        [JsonPropertyName("vendorGroupHash")]
        public DefinitionHashPointer<DestinyVendorGroupDefinition> VendorGroup { get; init; } =
            DefinitionHashPointer<DestinyVendorGroupDefinition>.Empty;

        [JsonPropertyName("vendorHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>> Vendors { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyVendorDefinition>>();
    }
}