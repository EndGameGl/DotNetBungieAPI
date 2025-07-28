namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This represents an item being sold by the vendor.
/// </summary>
public class DestinyVendorItemDefinition
{
    /// <summary>
    ///     The index into the DestinyVendorDefinition.saleList. This is what we use to refer to items being sold throughout live and definition data.
    /// </summary>
    [JsonPropertyName("vendorItemIndex")]
    public int VendorItemIndex { get; set; }

    /// <summary>
    ///     The hash identifier of the item being sold (DestinyInventoryItemDefinition).
    /// <para />
    ///     Note that a vendor can sell the same item in multiple ways, so don't assume that itemHash is a unique identifier for this entity.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    /// <summary>
    ///     The amount you will recieve of the item described in itemHash if you make the purchase.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    ///     An list of indexes into the DestinyVendorDefinition.failureStrings array, indicating the possible failure strings that can be relevant for this item.
    /// </summary>
    [JsonPropertyName("failureIndexes")]
    public int[]? FailureIndexes { get; set; }

    /// <summary>
    ///     This is a pre-compiled aggregation of item value and priceOverrideList, so that we have one place to check for what the purchaser must pay for the item. Use this instead of trying to piece together the price separately.
    /// <para />
    ///     The somewhat crappy part about this is that, now that item quantity overrides have dynamic modifiers, this will not necessarily be statically true. If you were using this instead of live data, switch to using live data.
    /// </summary>
    [JsonPropertyName("currencies")]
    public Destiny.Definitions.DestinyVendorItemQuantity[]? Currencies { get; set; }

    /// <summary>
    ///     If this item can be refunded, this is the policy for what will be refundd, how, and in what time period.
    /// </summary>
    [JsonPropertyName("refundPolicy")]
    public Destiny.DestinyVendorItemRefundPolicy RefundPolicy { get; set; }

    /// <summary>
    ///     The amount of time before refundability of the newly purchased item will expire.
    /// </summary>
    [JsonPropertyName("refundTimeLimit")]
    public int RefundTimeLimit { get; set; }

    /// <summary>
    ///     The Default level at which the item will spawn. Almost always driven by an adjusto these days. Ideally should be singular. It's a long story how this ended up as a list, but there is always either going to be 0:1 of these entities.
    /// </summary>
    [JsonPropertyName("creationLevels")]
    public Destiny.Definitions.DestinyItemCreationEntryLevelDefinition[]? CreationLevels { get; set; }

    /// <summary>
    ///     This is an index specifically into the display category, as opposed to the server-side Categories (which do not need to match or pair with each other in any way: server side categories are really just structures for common validation. Display Category will let us more easily categorize items visually)
    /// </summary>
    [JsonPropertyName("displayCategoryIndex")]
    public int DisplayCategoryIndex { get; set; }

    /// <summary>
    ///     The index into the DestinyVendorDefinition.categories array, so you can find the category associated with this item.
    /// </summary>
    [JsonPropertyName("categoryIndex")]
    public int CategoryIndex { get; set; }

    /// <summary>
    ///     Same as above, but for the original category indexes.
    /// </summary>
    [JsonPropertyName("originalCategoryIndex")]
    public int OriginalCategoryIndex { get; set; }

    /// <summary>
    ///     The minimum character level at which this item is available for sale.
    /// </summary>
    [JsonPropertyName("minimumLevel")]
    public int MinimumLevel { get; set; }

    /// <summary>
    ///     The maximum character level at which this item is available for sale.
    /// </summary>
    [JsonPropertyName("maximumLevel")]
    public int MaximumLevel { get; set; }

    /// <summary>
    ///     The action to be performed when purchasing the item, if it's not just "buy".
    /// </summary>
    [JsonPropertyName("action")]
    public Destiny.Definitions.DestinyVendorSaleItemActionBlockDefinition? Action { get; set; }

    /// <summary>
    ///     The string identifier for the category selling this item.
    /// </summary>
    [JsonPropertyName("displayCategory")]
    public string DisplayCategory { get; set; }

    /// <summary>
    ///     The inventory bucket into which this item will be placed upon purchase.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryBucketDefinition>("Destiny.Definitions.DestinyInventoryBucketDefinition")]
    [JsonPropertyName("inventoryBucketHash")]
    public uint InventoryBucketHash { get; set; }

    /// <summary>
    ///     The most restrictive scope that determines whether the item is available in the Vendor's inventory. See DestinyGatingScope's documentation for more information.
    /// <para />
    ///     This can be determined by Unlock gating, or by whether or not the item has purchase level requirements (minimumLevel and maximumLevel properties).
    /// </summary>
    [JsonPropertyName("visibilityScope")]
    public Destiny.DestinyGatingScope VisibilityScope { get; set; }

    /// <summary>
    ///     Similar to visibilityScope, it represents the most restrictive scope that determines whether the item can be purchased. It will at least be as restrictive as visibilityScope, but could be more restrictive if the item has additional purchase requirements beyond whether it is merely visible or not.
    /// <para />
    ///     See DestinyGatingScope's documentation for more information.
    /// </summary>
    [JsonPropertyName("purchasableScope")]
    public Destiny.DestinyGatingScope PurchasableScope { get; set; }

    /// <summary>
    ///     If this item can only be purchased by a given platform, this indicates the platform to which it is restricted.
    /// </summary>
    [JsonPropertyName("exclusivity")]
    public BungieMembershipType Exclusivity { get; set; }

    /// <summary>
    ///     If this sale can only be performed as the result of an offer check, this is true.
    /// </summary>
    [JsonPropertyName("isOffer")]
    public bool? IsOffer { get; set; }

    /// <summary>
    ///     If this sale can only be performed as the result of receiving a CRM offer, this is true.
    /// </summary>
    [JsonPropertyName("isCrm")]
    public bool? IsCrm { get; set; }

    /// <summary>
    ///     *if* the category this item is in supports non-default sorting, this value should represent the sorting value to use, pre-processed and ready to go.
    /// </summary>
    [JsonPropertyName("sortValue")]
    public int SortValue { get; set; }

    /// <summary>
    ///     If this item can expire, this is the tooltip message to show with its expiration info.
    /// </summary>
    [JsonPropertyName("expirationTooltip")]
    public string ExpirationTooltip { get; set; }

    /// <summary>
    ///     If this is populated, the purchase of this item should redirect to purchasing these other items instead.
    /// </summary>
    [JsonPropertyName("redirectToSaleIndexes")]
    public int[]? RedirectToSaleIndexes { get; set; }

    [JsonPropertyName("socketOverrides")]
    public Destiny.Definitions.DestinyVendorItemSocketOverride[]? SocketOverrides { get; set; }

    /// <summary>
    ///     If true, this item is some sort of dummy sale item that cannot actually be purchased. It may be a display only item, or some fluff left by a content designer for testing purposes, or something that got disabled because it was a terrible idea. You get the picture. We won't know *why* it can't be purchased, only that it can't be. Sorry.
    /// <para />
    ///     This is also only whether it's unpurchasable as a static property according to game content. There are other reasons why an item may or may not be purchasable at runtime, so even if this isn't set to True you should trust the runtime value for this sale item over the static definition if this is unset.
    /// </summary>
    [JsonPropertyName("unpurchasable")]
    public bool? Unpurchasable { get; set; }
}
