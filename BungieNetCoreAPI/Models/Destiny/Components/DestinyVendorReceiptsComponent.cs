using NetBungieAPI.Models.Destiny.Vendors;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyVendorReceiptsComponent
    {
        [JsonPropertyName("receipts")]
        public ReadOnlyCollection<DestinyVendorReceipt> Receipts { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorReceipt>();
    }
}
