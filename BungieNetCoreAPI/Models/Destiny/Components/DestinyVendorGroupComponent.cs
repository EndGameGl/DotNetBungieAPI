using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Vendors;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyVendorGroupComponent
    {
        [JsonPropertyName("groups")]
        public ReadOnlyCollection<DestinyVendorGroup> Groups { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorGroup>();
    }
}