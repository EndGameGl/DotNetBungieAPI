namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This is the definition for a single Vendor Category, into which Sale Items are grouped.
/// </summary>
public class DestinyVendorCategoryEntryDefinition
{
    /// <summary>
    ///     The index of the category in the original category definitions for the vendor.
    /// </summary>
    [JsonPropertyName("categoryIndex")]
    public int CategoryIndex { get; set; }

    /// <summary>
    ///     Used in sorting items in vendors... but there's a lot more to it. Just go with the order provided in the itemIndexes property on the DestinyVendorCategoryComponent instead, it should be more reliable than trying to recalculate it yourself.
    /// </summary>
    [JsonPropertyName("sortValue")]
    public int SortValue { get; set; }

    /// <summary>
    ///     The hashed identifier for the category.
    /// </summary>
    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; set; }

    /// <summary>
    ///     The amount of items that will be available when this category is shown.
    /// </summary>
    [JsonPropertyName("quantityAvailable")]
    public int QuantityAvailable { get; set; }

    /// <summary>
    ///     If items aren't up for sale in this category, should we still show them (greyed out)?
    /// </summary>
    [JsonPropertyName("showUnavailableItems")]
    public bool ShowUnavailableItems { get; set; }

    /// <summary>
    ///     If you don't have the currency required to buy items from this category, should the items be hidden?
    /// </summary>
    [JsonPropertyName("hideIfNoCurrency")]
    public bool HideIfNoCurrency { get; set; }

    /// <summary>
    ///     True if this category doesn't allow purchases.
    /// </summary>
    [JsonPropertyName("hideFromRegularPurchase")]
    public bool HideFromRegularPurchase { get; set; }

    /// <summary>
    ///     The localized string for making purchases from this category, if it is different from the vendor's string for purchasing.
    /// </summary>
    [JsonPropertyName("buyStringOverride")]
    public string BuyStringOverride { get; set; }

    /// <summary>
    ///     If the category is disabled, this is the localized description to show.
    /// </summary>
    [JsonPropertyName("disabledDescription")]
    public string DisabledDescription { get; set; }

    /// <summary>
    ///     The localized title of the category.
    /// </summary>
    [JsonPropertyName("displayTitle")]
    public string DisplayTitle { get; set; }

    /// <summary>
    ///     If this category has an overlay prompt that should appear, this contains the details of that prompt.
    /// </summary>
    [JsonPropertyName("overlay")]
    public Destiny.Definitions.DestinyVendorCategoryOverlayDefinition? Overlay { get; set; }

    /// <summary>
    ///     A shortcut for the vendor item indexes sold under this category. Saves us from some expensive reorganization at runtime.
    /// </summary>
    [JsonPropertyName("vendorItemIndexes")]
    public int[]? VendorItemIndexes { get; set; }

    /// <summary>
    ///     Sometimes a category isn't actually used to sell items, but rather to preview them. This implies different UI (and manual placement of the category in the UI) in the game, and special treatment.
    /// </summary>
    [JsonPropertyName("isPreview")]
    public bool IsPreview { get; set; }

    /// <summary>
    ///     If true, this category only displays items: you can't purchase anything in them.
    /// </summary>
    [JsonPropertyName("isDisplayOnly")]
    public bool IsDisplayOnly { get; set; }

    [JsonPropertyName("resetIntervalMinutesOverride")]
    public int ResetIntervalMinutesOverride { get; set; }

    [JsonPropertyName("resetOffsetMinutesOverride")]
    public int ResetOffsetMinutesOverride { get; set; }
}
