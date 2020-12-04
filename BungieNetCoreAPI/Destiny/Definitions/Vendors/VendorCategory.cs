using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorCategory
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
        public List<int> VendorItemIndexes { get; }

        [JsonConstructor]
        private VendorCategory(string buyStringOverride, uint categoryHash, int categoryIndex, string disabledDescription, bool hideFromRegularPurchase,
            bool hideIfNoCurrency, bool isDisplayOnly, bool isPreview, int quantityAvailable, int resetIntervalMinutesOverride, int resetOffsetMinutesOverride,
            bool showUnavailableItems, int sortValue, List<int> vendorItemIndexes)
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
            VendorItemIndexes = vendorItemIndexes;
        }
    }
}
