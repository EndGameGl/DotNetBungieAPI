namespace DotNetBungieAPI.Generated.Models.Destiny.Vendors;

/// <summary>
///     If a character purchased an item that is refundable, a Vendor Receipt will be created on the user's Destiny Profile. These expire after a configurable period of time, but until then can be used to get refunds on items. BNet does not provide the ability to refund a purchase *yet*, but you know.
/// </summary>
public class DestinyVendorReceipt
{
    /// <summary>
    ///     The amount paid for the item, in terms of items that were consumed in the purchase and their quantity.
    /// </summary>
    [JsonPropertyName("currencyPaid")]
    public Destiny.DestinyItemQuantity[]? CurrencyPaid { get; set; }

    /// <summary>
    ///     The item that was received, and its quantity.
    /// </summary>
    [JsonPropertyName("itemReceived")]
    public Destiny.DestinyItemQuantity? ItemReceived { get; set; }

    /// <summary>
    ///     The unlock flag used to determine whether you still have the purchased item.
    /// </summary>
    [JsonPropertyName("licenseUnlockHash")]
    public uint LicenseUnlockHash { get; set; }

    /// <summary>
    ///     The ID of the character who made the purchase.
    /// </summary>
    [JsonPropertyName("purchasedByCharacterId")]
    public long PurchasedByCharacterId { get; set; }

    /// <summary>
    ///     Whether you can get a refund, and what happens in order for the refund to be received. See the DestinyVendorItemRefundPolicy enum for details.
    /// </summary>
    [JsonPropertyName("refundPolicy")]
    public Destiny.DestinyVendorItemRefundPolicy RefundPolicy { get; set; }

    /// <summary>
    ///     The identifier of this receipt.
    /// </summary>
    [JsonPropertyName("sequenceNumber")]
    public int SequenceNumber { get; set; }

    /// <summary>
    ///     The seconds since epoch at which this receipt is rendered invalid.
    /// </summary>
    [JsonPropertyName("timeToExpiration")]
    public long TimeToExpiration { get; set; }

    /// <summary>
    ///     The date at which this receipt is rendered invalid.
    /// </summary>
    [JsonPropertyName("expiresOn")]
    public DateTime ExpiresOn { get; set; }
}
