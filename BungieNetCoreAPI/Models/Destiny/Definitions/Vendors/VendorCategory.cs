using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorCategory : IDeepEquatable<VendorCategory>
    {
        public string BuyStringOverride { get; init; }
        public uint CategoryHash { get; init; }
        public int CategoryIndex { get; init; }
        public string DisabledDescription { get; init; }
        public bool HideFromRegularPurchase { get; init; }
        public bool HideIfNoCurrency { get; init; }
        public bool IsDisplayOnly { get; init; }
        public bool IsPreview { get; init; }
        public int QuantityAvailable { get; init; }
        public int ResetIntervalMinutesOverride { get; init; }
        public int ResetOffsetMinutesOverride { get; init; }
        public bool ShowUnavailableItems { get; init; }
        public int SortValue { get; init; }
        public ReadOnlyCollection<int> VendorItemIndexes { get; init; }
        public string DisplayTitle { get; init; }
        public VendorCategoryOverlay Overlay { get; init; }

        [JsonConstructor]
        internal VendorCategory(string buyStringOverride, uint categoryHash, int categoryIndex, string disabledDescription, bool hideFromRegularPurchase,
            bool hideIfNoCurrency, bool isDisplayOnly, bool isPreview, int quantityAvailable, int resetIntervalMinutesOverride, int resetOffsetMinutesOverride,
            bool showUnavailableItems, int sortValue, int[] vendorItemIndexes, string displayTitle, VendorCategoryOverlay overlay)
        {
            BuyStringOverride = buyStringOverride;
            CategoryHash = categoryHash;
            CategoryIndex = categoryIndex;
            DisabledDescription = disabledDescription;
            HideFromRegularPurchase = hideFromRegularPurchase;
            HideIfNoCurrency = hideIfNoCurrency;
            IsDisplayOnly = isDisplayOnly;
            IsPreview = isPreview;
            QuantityAvailable = quantityAvailable;
            ResetIntervalMinutesOverride = resetIntervalMinutesOverride;
            ResetOffsetMinutesOverride = resetIntervalMinutesOverride;
            ShowUnavailableItems = showUnavailableItems;
            SortValue = sortValue;
            VendorItemIndexes = vendorItemIndexes.AsReadOnlyOrEmpty();
            DisplayTitle = displayTitle;
            Overlay = overlay;
        }

        public bool DeepEquals(VendorCategory other)
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
