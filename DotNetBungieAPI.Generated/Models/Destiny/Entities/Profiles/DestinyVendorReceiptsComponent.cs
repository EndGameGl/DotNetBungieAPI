namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Profiles;

/// <summary>
///     For now, this isn't used for much: it's a record of the recent refundable purchases that the user has made. In the future, it could be used for providing refunds/buyback via the API. Wouldn't that be fun?
/// </summary>
public class DestinyVendorReceiptsComponent : IDeepEquatable<DestinyVendorReceiptsComponent>
{
    /// <summary>
    ///     The receipts for refundable purchases made at a vendor.
    /// </summary>
    [JsonPropertyName("receipts")]
    public List<Destiny.Vendors.DestinyVendorReceipt> Receipts { get; set; }

    public bool DeepEquals(DestinyVendorReceiptsComponent? other)
    {
        return other is not null &&
               Receipts.DeepEqualsList(other.Receipts);
    }
}