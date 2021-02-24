using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorReceipt
    {
        public ReadOnlyCollection<DestinyItemQuantity> CurrencyPaid { get; }
        public ReadOnlyCollection<DestinyItemQuantity> ItemReceived { get; }
        public uint LicenseUnlockHash { get; }
        public long PurchasedByCharacterId { get; }
        public DestinyVendorItemRefundPolicy RefundPolicy { get; }
        public int SequenceNumber { get; }
        public long TimeToExpiration { get; }
        public DateTime ExpiresOn { get; }

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
