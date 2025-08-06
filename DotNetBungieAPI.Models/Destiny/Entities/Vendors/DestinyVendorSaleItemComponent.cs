namespace DotNetBungieAPI.Models.Destiny.Entities.Vendors;

/// <summary>
///     Request this component if you want the details about an item being sold in relation to the character making the request: whether the character can buy it, whether they can afford it, and other data related to purchasing the item.
/// <para />
///     Note that if you want instance, stats, etc... data for the item, you'll have to request additional components such as ItemInstances, ItemPerks etc... and acquire them from the DestinyVendorResponse's "items" property.
/// </summary>
public sealed class DestinyVendorSaleItemComponent
{
    /// <summary>
    ///     A flag indicating whether the requesting character can buy the item, and if not the reasons why the character can't buy it.
    /// </summary>
    [JsonPropertyName("saleStatus")]
    public Destiny.VendorItemStatus SaleStatus { get; init; }

    /// <summary>
    ///     If you can't buy the item due to a complex character state, these will be hashes for DestinyUnlockDefinitions that you can check to see messages regarding the failure (if the unlocks have human readable information: it is not guaranteed that Unlocks will have human readable strings, and your application will have to handle that)
    /// <para />
    ///     Prefer using failureIndexes instead. These are provided for informational purposes, but have largely been supplanted by failureIndexes.
    /// </summary>
    [JsonPropertyName("requiredUnlocks")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyUnlockDefinition>[]? RequiredUnlocks { get; init; }

    /// <summary>
    ///     If any complex unlock states are checked in determining purchasability, these will be returned here along with the status of the unlock check.
    /// <para />
    ///     Prefer using failureIndexes instead. These are provided for informational purposes, but have largely been supplanted by failureIndexes.
    /// </summary>
    [JsonPropertyName("unlockStatuses")]
    public Destiny.DestinyUnlockStatus[]? UnlockStatuses { get; init; }

    /// <summary>
    ///     Indexes in to the "failureStrings" lookup table in DestinyVendorDefinition for the given Vendor. Gives some more reliable failure information for why you can't purchase an item.
    /// <para />
    ///     It is preferred to use these over requiredUnlocks and unlockStatuses: the latter are provided mostly in case someone can do something interesting with it that I didn't anticipate.
    /// </summary>
    [JsonPropertyName("failureIndexes")]
    public int[]? FailureIndexes { get; init; }

    /// <summary>
    ///     A flags enumeration value representing the current state of any "state modifiers" on the item being sold. These are meant to correspond with some sort of visual indicator as to the augmentation: for instance, if an item is on sale or if you already own the item in question.
    /// <para />
    ///     Determining how you want to represent these in your own app (or if you even want to) is an exercise left for the reader.
    /// </summary>
    [JsonPropertyName("augments")]
    public Destiny.DestinyVendorItemState Augments { get; init; }

    /// <summary>
    ///     If available, a list that describes which item values (rewards) should be shown (true) or hidden (false).
    /// </summary>
    [JsonPropertyName("itemValueVisibility")]
    public bool[]? ItemValueVisibility { get; init; }

    /// <summary>
    ///     The index into the DestinyVendorDefinition.itemList property. Note that this means Vendor data *is* Content Version dependent: make sure you have the latest content before you use Vendor data, or these indexes may mismatch. 
    /// <para />
    ///     Most systems avoid this problem, but Vendors is one area where we are unable to reasonably avoid content dependency at the moment.
    /// </summary>
    [JsonPropertyName("vendorItemIndex")]
    public int VendorItemIndex { get; init; }

    /// <summary>
    ///     The hash of the item being sold, as a quick shortcut for looking up the DestinyInventoryItemDefinition of the sale item.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> ItemHash { get; init; }

    /// <summary>
    ///     If populated, this is the hash of the item whose icon (and other secondary styles, but *not* the human readable strings) should override whatever icons/styles are on the item being sold.
    /// <para />
    ///     If you don't do this, certain items whose styles are being overridden by socketed items - such as the "Recycle Shader" item - would show whatever their default icon/style is, and it wouldn't be pretty or look accurate.
    /// </summary>
    [JsonPropertyName("overrideStyleItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>? OverrideStyleItemHash { get; init; }

    /// <summary>
    ///     How much of the item you'll be getting.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    ///     A summary of the current costs of the item.
    /// </summary>
    [JsonPropertyName("costs")]
    public Destiny.DestinyItemQuantity[]? Costs { get; init; }

    /// <summary>
    ///     If this item has its own custom date where it may be removed from the Vendor's rotation, this is that date.
    /// <para />
    ///     Note that there's not actually any guarantee that it will go away: it could be chosen again and end up still being in the Vendor's sale items! But this is the next date where that test will occur, and is also the date that the game shows for availability on things like Bounties being sold. So it's the best we can give.
    /// </summary>
    [JsonPropertyName("overrideNextRefreshDate")]
    public DateTime? OverrideNextRefreshDate { get; init; }

    /// <summary>
    ///     If true, this item can be purchased through the Bungie.net API.
    /// </summary>
    [JsonPropertyName("apiPurchasable")]
    public bool? ApiPurchasable { get; init; }
}
