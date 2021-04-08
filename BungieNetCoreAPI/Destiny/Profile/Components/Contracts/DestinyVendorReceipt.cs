using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorReceipt
    {
        public ReadOnlyCollection<DestinyItemQuantity> CurrencyPaid { get; init; }
        public ReadOnlyCollection<DestinyItemQuantity> ItemReceived { get; init; }
        public uint LicenseUnlockHash { get; init; }
        public long PurchasedByCharacterId { get; init; }
        public DestinyVendorItemRefundPolicy RefundPolicy { get; init; }
        public int SequenceNumber { get; init; }
        public long TimeToExpiration { get; init; }
        public DateTime ExpiresOn { get; init; }

        [JsonConstructor]
        internal DestinyVendorReceipt(DestinyItemQuantity[] currencyPaid, DestinyItemQuantity[] itemReceived, uint licenseUnlockHash, long purchasedByCharacterId,
            DestinyVendorItemRefundPolicy refundPolicy, int sequenceNumber, long timeToExpiration, DateTime expiresOn)
        {
            CurrencyPaid = currencyPaid.AsReadOnlyOrEmpty();
            ItemReceived = itemReceived.AsReadOnlyOrEmpty();
            LicenseUnlockHash = licenseUnlockHash;
            PurchasedByCharacterId = purchasedByCharacterId;
            RefundPolicy = refundPolicy;
            SequenceNumber = sequenceNumber;
            TimeToExpiration = timeToExpiration;
            ExpiresOn = expiresOn;
        }
    }
}
