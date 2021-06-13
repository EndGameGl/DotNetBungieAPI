using NetBungieAPI.Models.Destiny.Vendors;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    /// For now, this isn't used for much: it's a record of the recent refundable purchases that the user has made. In the future, it could be used for providing refunds/buyback via the API. Wouldn't that be fun?
    /// </summary>
    public sealed record DestinyVendorReceiptsComponent
    {
        /// <summary>
        /// The receipts for refundable purchases made at a vendor.
        /// </summary>
        [JsonPropertyName("receipts")]
        public ReadOnlyCollection<DestinyVendorReceipt> Receipts { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorReceipt>();
    }
}