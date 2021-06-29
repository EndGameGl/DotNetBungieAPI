using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     This is the definition for a single Vendor Category, into which Sale Items are grouped.
    /// </summary>
    public sealed record DestinyVendorCategoryEntryDefinition : IDeepEquatable<DestinyVendorCategoryEntryDefinition>
    {
        /// <summary>
        ///     The localized string for making purchases from this category, if it is different from the vendor's string for
        ///     purchasing.
        /// </summary>
        [JsonPropertyName("buyStringOverride")]
        public string BuyStringOverride { get; init; }

        /// <summary>
        ///     The hashed identifier for the category.
        /// </summary>
        [JsonPropertyName("categoryHash")]
        public uint CategoryHash { get; init; }

        /// <summary>
        ///     The index of the category in the original category definitions for the vendor.
        /// </summary>
        [JsonPropertyName("categoryIndex")]
        public int CategoryIndex { get; init; }

        /// <summary>
        ///     If the category is disabled, this is the localized description to show.
        /// </summary>
        [JsonPropertyName("disabledDescription")]
        public string DisabledDescription { get; init; }

        /// <summary>
        ///     True if this category doesn't allow purchases.
        /// </summary>
        [JsonPropertyName("hideFromRegularPurchase")]
        public bool HideFromRegularPurchase { get; init; }

        /// <summary>
        ///     If you don't have the currency required to buy items from this category, should the items be hidden?
        /// </summary>
        [JsonPropertyName("hideIfNoCurrency")]
        public bool HideIfNoCurrency { get; init; }

        /// <summary>
        ///     If true, this category only displays items: you can't purchase anything in them.
        /// </summary>
        [JsonPropertyName("isDisplayOnly")]
        public bool IsDisplayOnly { get; init; }

        /// <summary>
        ///     Sometimes a category isn't actually used to sell items, but rather to preview them. This implies different UI (and
        ///     manual placement of the category in the UI) in the game, and special treatment.
        /// </summary>
        [JsonPropertyName("isPreview")]
        public bool IsPreview { get; init; }

        /// <summary>
        ///     The amount of items that will be available when this category is shown.
        /// </summary>
        [JsonPropertyName("quantityAvailable")]
        public int QuantityAvailable { get; init; }

        [JsonPropertyName("resetIntervalMinutesOverride")]
        public int ResetIntervalMinutesOverride { get; init; }

        [JsonPropertyName("resetOffsetMinutesOverride")]
        public int ResetOffsetMinutesOverride { get; init; }

        /// <summary>
        ///     If items aren't up for sale in this category, should we still show them (greyed out)?
        /// </summary>
        [JsonPropertyName("showUnavailableItems")]
        public bool ShowUnavailableItems { get; init; }

        /// <summary>
        ///     Used in sorting items in vendors... but there's a lot more to it. Just go with the order provided in the
        ///     itemIndexes property on the DestinyVendorCategoryComponent instead, it should be more reliable than trying to
        ///     recalculate it yourself.
        /// </summary>
        [JsonPropertyName("sortValue")]
        public VendorDisplayCategorySortOrder SortValue { get; init; }

        /// <summary>
        ///     A shortcut for the vendor item indexes sold under this category. Saves us from some expensive reorganization at
        ///     runtime.
        /// </summary>
        [JsonPropertyName("vendorItemIndexes")]
        public ReadOnlyCollection<int> VendorItemIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        /// <summary>
        ///     The localized title of the category.
        /// </summary>
        [JsonPropertyName("displayTitle")]
        public string DisplayTitle { get; init; }

        /// <summary>
        ///     If this category has an overlay prompt that should appear, this contains the details of that prompt.
        /// </summary>
        [JsonPropertyName("overlay")]
        public DestinyVendorCategoryOverlayDefinition Overlay { get; init; }

        public bool DeepEquals(DestinyVendorCategoryEntryDefinition other)
        {
            return other != null &&
                   BuyStringOverride == other.BuyStringOverride &&
                   CategoryHash == other.CategoryHash &&
                   CategoryIndex == other.CategoryIndex &&
                   DisabledDescription == other.DisabledDescription &&
                   HideFromRegularPurchase == other.HideFromRegularPurchase &&
                   HideIfNoCurrency == other.HideIfNoCurrency &&
                   IsDisplayOnly == other.IsDisplayOnly &&
                   IsPreview == other.IsPreview &&
                   QuantityAvailable == other.QuantityAvailable &&
                   ResetIntervalMinutesOverride == other.ResetIntervalMinutesOverride &&
                   ResetOffsetMinutesOverride == other.ResetOffsetMinutesOverride &&
                   ShowUnavailableItems == other.ShowUnavailableItems &&
                   SortValue == other.SortValue &&
                   VendorItemIndexes.DeepEqualsReadOnlySimpleCollection(other.VendorItemIndexes) &&
                   DisplayTitle == other.DisplayTitle &&
                   Overlay.DeepEquals(other.Overlay);
        }
    }
}