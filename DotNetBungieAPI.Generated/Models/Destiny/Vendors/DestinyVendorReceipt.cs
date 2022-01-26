namespace DotNetBungieAPI.Generated.Models.Destiny.Vendors;

/// <summary>
///     If a character purchased an item that is refundable, a Vendor Receipt will be created on the user's Destiny Profile. These expire after a configurable period of time, but until then can be used to get refunds on items. BNet does not provide the ability to refund a purchase *yet*, but you know.
/// </summary>
public class DestinyVendorReceipt : IDeepEquatable<DestinyVendorReceipt>
{
    /// <summary>
    ///     The amount paid for the item, in terms of items that were consumed in the purchase and their quantity.
    /// </summary>
    [JsonPropertyName("currencyPaid")]
    public List<Destiny.DestinyItemQuantity> CurrencyPaid { get; set; }

    /// <summary>
    ///     The item that was received, and its quantity.
    /// </summary>
    [JsonPropertyName("itemReceived")]
    public Destiny.DestinyItemQuantity ItemReceived { get; set; }

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

    public bool DeepEquals(DestinyVendorReceipt? other)
    {
        return other is not null &&
               CurrencyPaid.DeepEqualsList(other.CurrencyPaid) &&
               (ItemReceived is not null ? ItemReceived.DeepEquals(other.ItemReceived) : other.ItemReceived is null) &&
               LicenseUnlockHash == other.LicenseUnlockHash &&
               PurchasedByCharacterId == other.PurchasedByCharacterId &&
               RefundPolicy == other.RefundPolicy &&
               SequenceNumber == other.SequenceNumber &&
               TimeToExpiration == other.TimeToExpiration &&
               ExpiresOn == other.ExpiresOn;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorReceipt? other)
    {
        if (other is null) return;
        if (!CurrencyPaid.DeepEqualsList(other.CurrencyPaid))
        {
            CurrencyPaid = other.CurrencyPaid;
            OnPropertyChanged(nameof(CurrencyPaid));
        }
        if (!ItemReceived.DeepEquals(other.ItemReceived))
        {
            ItemReceived.Update(other.ItemReceived);
            OnPropertyChanged(nameof(ItemReceived));
        }
        if (LicenseUnlockHash != other.LicenseUnlockHash)
        {
            LicenseUnlockHash = other.LicenseUnlockHash;
            OnPropertyChanged(nameof(LicenseUnlockHash));
        }
        if (PurchasedByCharacterId != other.PurchasedByCharacterId)
        {
            PurchasedByCharacterId = other.PurchasedByCharacterId;
            OnPropertyChanged(nameof(PurchasedByCharacterId));
        }
        if (RefundPolicy != other.RefundPolicy)
        {
            RefundPolicy = other.RefundPolicy;
            OnPropertyChanged(nameof(RefundPolicy));
        }
        if (SequenceNumber != other.SequenceNumber)
        {
            SequenceNumber = other.SequenceNumber;
            OnPropertyChanged(nameof(SequenceNumber));
        }
        if (TimeToExpiration != other.TimeToExpiration)
        {
            TimeToExpiration = other.TimeToExpiration;
            OnPropertyChanged(nameof(TimeToExpiration));
        }
        if (ExpiresOn != other.ExpiresOn)
        {
            ExpiresOn = other.ExpiresOn;
            OnPropertyChanged(nameof(ExpiresOn));
        }
    }
}