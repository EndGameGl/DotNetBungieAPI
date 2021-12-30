using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Vendors;

public sealed class DestinyVendorReceipt
{

    [JsonPropertyName("currencyPaid")]
    public List<Destiny.DestinyItemQuantity> CurrencyPaid { get; init; }

    [JsonPropertyName("itemReceived")]
    public Destiny.DestinyItemQuantity ItemReceived { get; init; }

    [JsonPropertyName("licenseUnlockHash")]
    public uint LicenseUnlockHash { get; init; }

    [JsonPropertyName("purchasedByCharacterId")]
    public long PurchasedByCharacterId { get; init; }

    [JsonPropertyName("refundPolicy")]
    public Destiny.DestinyVendorItemRefundPolicy RefundPolicy { get; init; }

    [JsonPropertyName("sequenceNumber")]
    public int SequenceNumber { get; init; }

    [JsonPropertyName("timeToExpiration")]
    public long TimeToExpiration { get; init; }

    [JsonPropertyName("expiresOn")]
    public DateTime ExpiresOn { get; init; }
}
