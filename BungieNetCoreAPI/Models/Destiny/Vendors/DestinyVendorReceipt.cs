using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Vendors
{
    public sealed record DestinyVendorReceipt
    {
        [JsonPropertyName("currencyPaid")]
        public ReadOnlyCollection<DestinyItemQuantity> CurrencyPaid { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
        [JsonPropertyName("itemReceived")]
        public ReadOnlyCollection<DestinyItemQuantity> ItemReceived { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
        [JsonPropertyName("licenseUnlockHash")]
        public uint LicenseUnlockHash { get; init; }
        [JsonPropertyName("purchasedByCharacterId")]
        public long PurchasedByCharacterId { get; init; }
        [JsonPropertyName("refundPolicy")]
        public DestinyVendorItemRefundPolicy RefundPolicy { get; init; }
        [JsonPropertyName("sequenceNumber")]
        public int SequenceNumber { get; init; }
        [JsonPropertyName("timeToExpiration")]
        public long TimeToExpiration { get; init; }
        [JsonPropertyName("expiresOn")]
        public DateTime ExpiresOn { get; init; }
    }
}
