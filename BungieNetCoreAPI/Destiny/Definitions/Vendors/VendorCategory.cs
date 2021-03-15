using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorCategory : IDeepEquatable<VendorCategory>
    {
        public string BuyStringOverride { get; }
        public uint CategoryHash { get; }
        public int CategoryIndex { get; }
        public string DisabledDescription { get; }
        public bool HideFromRegularPurchase { get; }
        public bool HideIfNoCurrency { get; }
        public bool IsDisplayOnly { get; }
        public bool IsPreview { get; }
        public int QuantityAvailable { get; }
        public int ResetIntervalMinutesOverride { get; }
        public int ResetOffsetMinutesOverride { get; }
        public bool ShowUnavailableItems { get; }
        public int SortValue { get; }
        public ReadOnlyCollection<int> VendorItemIndexes { get; }
        public string DisplayTitle { get; }
        public VendorCategoryOverlay Overlay { get; }

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
