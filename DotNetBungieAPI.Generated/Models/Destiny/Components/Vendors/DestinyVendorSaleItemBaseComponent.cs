namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

/// <summary>
///     The base class for Vendor Sale Item data. Has a bunch of character-agnostic state about the item being sold.
/// <para />
///     Note that if you want instance, stats, etc... data for the item, you'll have to request additional components such as ItemInstances, ItemPerks etc... and acquire them from the DestinyVendorResponse's "items" property.
/// </summary>
public class DestinyVendorSaleItemBaseComponent
{
    /// <summary>
    ///     The index into the DestinyVendorDefinition.itemList property. Note that this means Vendor data *is* Content Version dependent: make sure you have the latest content before you use Vendor data, or these indexes may mismatch. 
    /// <para />
    ///     Most systems avoid this problem, but Vendors is one area where we are unable to reasonably avoid content dependency at the moment.
    /// </summary>
    [JsonPropertyName("vendorItemIndex")]
    public int? VendorItemIndex { get; set; }

    /// <summary>
    ///     The hash of the item being sold, as a quick shortcut for looking up the DestinyInventoryItemDefinition of the sale item.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    /// <summary>
    ///     If populated, this is the hash of the item whose icon (and other secondary styles, but *not* the human readable strings) should override whatever icons/styles are on the item being sold.
    /// <para />
    ///     If you don't do this, certain items whose styles are being overridden by socketed items - such as the "Recycle Shader" item - would show whatever their default icon/style is, and it wouldn't be pretty or look accurate.
    /// </summary>
    [JsonPropertyName("overrideStyleItemHash")]
    public uint? OverrideStyleItemHash { get; set; }

    /// <summary>
    ///     How much of the item you'll be getting.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    /// <summary>
    ///     A summary of the current costs of the item.
    /// </summary>
    [JsonPropertyName("costs")]
    public List<Destiny.DestinyItemQuantity> Costs { get; set; }

    /// <summary>
    ///     If this item has its own custom date where it may be removed from the Vendor's rotation, this is that date.
    /// <para />
    ///     Note that there's not actually any guarantee that it will go away: it could be chosen again and end up still being in the Vendor's sale items! But this is the next date where that test will occur, and is also the date that the game shows for availability on things like Bounties being sold. So it's the best we can give.
    /// </summary>
    [JsonPropertyName("overrideNextRefreshDate")]
    public DateTime? OverrideNextRefreshDate { get; set; }

    /// <summary>
    ///     If true, this item can be purchased through the Bungie.net API.
    /// </summary>
    [JsonPropertyName("apiPurchasable")]
    public bool? ApiPurchasable { get; set; }
}
