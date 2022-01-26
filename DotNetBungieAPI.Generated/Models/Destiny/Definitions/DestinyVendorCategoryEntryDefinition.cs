namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This is the definition for a single Vendor Category, into which Sale Items are grouped.
/// </summary>
public class DestinyVendorCategoryEntryDefinition : IDeepEquatable<DestinyVendorCategoryEntryDefinition>
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
    public Destiny.Definitions.DestinyVendorCategoryOverlayDefinition Overlay { get; set; }

    /// <summary>
    ///     A shortcut for the vendor item indexes sold under this category. Saves us from some expensive reorganization at runtime.
    /// </summary>
    [JsonPropertyName("vendorItemIndexes")]
    public List<int> VendorItemIndexes { get; set; }

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

    public bool DeepEquals(DestinyVendorCategoryEntryDefinition? other)
    {
        return other is not null &&
               CategoryIndex == other.CategoryIndex &&
               SortValue == other.SortValue &&
               CategoryHash == other.CategoryHash &&
               QuantityAvailable == other.QuantityAvailable &&
               ShowUnavailableItems == other.ShowUnavailableItems &&
               HideIfNoCurrency == other.HideIfNoCurrency &&
               HideFromRegularPurchase == other.HideFromRegularPurchase &&
               BuyStringOverride == other.BuyStringOverride &&
               DisabledDescription == other.DisabledDescription &&
               DisplayTitle == other.DisplayTitle &&
               (Overlay is not null ? Overlay.DeepEquals(other.Overlay) : other.Overlay is null) &&
               VendorItemIndexes.DeepEqualsListNaive(other.VendorItemIndexes) &&
               IsPreview == other.IsPreview &&
               IsDisplayOnly == other.IsDisplayOnly &&
               ResetIntervalMinutesOverride == other.ResetIntervalMinutesOverride &&
               ResetOffsetMinutesOverride == other.ResetOffsetMinutesOverride;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorCategoryEntryDefinition? other)
    {
        if (other is null) return;
        if (CategoryIndex != other.CategoryIndex)
        {
            CategoryIndex = other.CategoryIndex;
            OnPropertyChanged(nameof(CategoryIndex));
        }
        if (SortValue != other.SortValue)
        {
            SortValue = other.SortValue;
            OnPropertyChanged(nameof(SortValue));
        }
        if (CategoryHash != other.CategoryHash)
        {
            CategoryHash = other.CategoryHash;
            OnPropertyChanged(nameof(CategoryHash));
        }
        if (QuantityAvailable != other.QuantityAvailable)
        {
            QuantityAvailable = other.QuantityAvailable;
            OnPropertyChanged(nameof(QuantityAvailable));
        }
        if (ShowUnavailableItems != other.ShowUnavailableItems)
        {
            ShowUnavailableItems = other.ShowUnavailableItems;
            OnPropertyChanged(nameof(ShowUnavailableItems));
        }
        if (HideIfNoCurrency != other.HideIfNoCurrency)
        {
            HideIfNoCurrency = other.HideIfNoCurrency;
            OnPropertyChanged(nameof(HideIfNoCurrency));
        }
        if (HideFromRegularPurchase != other.HideFromRegularPurchase)
        {
            HideFromRegularPurchase = other.HideFromRegularPurchase;
            OnPropertyChanged(nameof(HideFromRegularPurchase));
        }
        if (BuyStringOverride != other.BuyStringOverride)
        {
            BuyStringOverride = other.BuyStringOverride;
            OnPropertyChanged(nameof(BuyStringOverride));
        }
        if (DisabledDescription != other.DisabledDescription)
        {
            DisabledDescription = other.DisabledDescription;
            OnPropertyChanged(nameof(DisabledDescription));
        }
        if (DisplayTitle != other.DisplayTitle)
        {
            DisplayTitle = other.DisplayTitle;
            OnPropertyChanged(nameof(DisplayTitle));
        }
        if (!Overlay.DeepEquals(other.Overlay))
        {
            Overlay.Update(other.Overlay);
            OnPropertyChanged(nameof(Overlay));
        }
        if (!VendorItemIndexes.DeepEqualsListNaive(other.VendorItemIndexes))
        {
            VendorItemIndexes = other.VendorItemIndexes;
            OnPropertyChanged(nameof(VendorItemIndexes));
        }
        if (IsPreview != other.IsPreview)
        {
            IsPreview = other.IsPreview;
            OnPropertyChanged(nameof(IsPreview));
        }
        if (IsDisplayOnly != other.IsDisplayOnly)
        {
            IsDisplayOnly = other.IsDisplayOnly;
            OnPropertyChanged(nameof(IsDisplayOnly));
        }
        if (ResetIntervalMinutesOverride != other.ResetIntervalMinutesOverride)
        {
            ResetIntervalMinutesOverride = other.ResetIntervalMinutesOverride;
            OnPropertyChanged(nameof(ResetIntervalMinutesOverride));
        }
        if (ResetOffsetMinutesOverride != other.ResetOffsetMinutesOverride)
        {
            ResetOffsetMinutesOverride = other.ResetOffsetMinutesOverride;
            OnPropertyChanged(nameof(ResetOffsetMinutesOverride));
        }
    }
}