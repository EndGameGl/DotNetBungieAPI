using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorCategoryEntryDefinition : IDeepEquatable<DestinyVendorCategoryEntryDefinition>
    {
        [JsonPropertyName("buyStringOverride")]
        public string BuyStringOverride { get; init; }
        [JsonPropertyName("categoryHash")]
        public uint CategoryHash { get; init; }
        [JsonPropertyName("categoryIndex")]
        public int CategoryIndex { get; init; }
        [JsonPropertyName("disabledDescription")]
        public string DisabledDescription { get; init; }
        [JsonPropertyName("hideFromRegularPurchase")]
        public bool HideFromRegularPurchase { get; init; }
        [JsonPropertyName("hideIfNoCurrency")]
        public bool HideIfNoCurrency { get; init; }
        [JsonPropertyName("isDisplayOnly")]
        public bool IsDisplayOnly { get; init; }
        [JsonPropertyName("isPreview")]
        public bool IsPreview { get; init; }
        [JsonPropertyName("quantityAvailable")]
        public int QuantityAvailable { get; init; }
        [JsonPropertyName("resetIntervalMinutesOverride")]
        public int ResetIntervalMinutesOverride { get; init; }
        [JsonPropertyName("resetOffsetMinutesOverride")]
        public int ResetOffsetMinutesOverride { get; init; }
        [JsonPropertyName("showUnavailableItems")]
        public bool ShowUnavailableItems { get; init; }
        [JsonPropertyName("sortValue")]
        public VendorDisplayCategorySortOrder SortValue { get; init; }
        [JsonPropertyName("vendorItemIndexes")]
        public ReadOnlyCollection<int> VendorItemIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("displayTitle")]
        public string DisplayTitle { get; init; }
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
