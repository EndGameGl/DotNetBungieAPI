using NetBungieAPI.Models.Destiny.Definitions.Vendors;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyKiosksComponent
    {
        [JsonPropertyName("kioskItems")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyVendorDefinition>, object[]> KioskItems { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyVendorDefinition>, object[]>();
    }
}
