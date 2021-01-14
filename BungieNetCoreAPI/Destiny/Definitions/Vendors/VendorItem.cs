using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterPointers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorItem
    {
        public VendorItemAction Action { get; }
        public int CategoryIndex { get; }
        public List<VendorItemCreationLevel> CreationLevels { get; }
        public List<VendorItemCurrency> Currencies { get; }
        public string DisplayCategory { get; }
        public int DisplayCategoryIndex { get; }
        public int Exclusivity { get; }
        public string ExpirationTooltip { get; }
        public List<int> FailureIndexes { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public uint LicenseUnlockHash { get; }
        public int MaximumLevel { get; }
        public int MinimumLevel { get; }
        public int OriginalCategoryIndex { get; }
        public bool PriceOverrideEnabled { get; }
        public int PurchasableScope { get; }
        public int Quantity { get; }
        public List<int> RedirectToSaleIndexes { get; }
        public int RefundPolicy { get; }
        public int RefundTimeLimit { get; }
        public DefinitionHashPointer<DestinyRewardAdjusterPointerDefinition> RewardAdjustorPointer { get; }
        public int SeedOverride { get; }
        public List<VendorItemSocketOverride> SocketOverrides { get; }
        public int SortValue { get; }
        public int VendorItemIndex { get; }
        public int VisibilityScope { get; }
        public double Weight { get; }

        [JsonConstructor]
        private VendorItem(VendorItemAction action, int categoryIndex, List<VendorItemCreationLevel> creationLevels, List<VendorItemCurrency> currencies, string displayCategory,
            int displayCategoryIndex, int exclusivity, string expirationTooltip, List<int> failureIndexes, uint inventoryBucketHash, uint itemHash,
            uint licenseUnlockHash, int maximumLevel, int minimumLevel, int originalCategoryIndex, bool priceOverrideEnabled, int purchasableScope,
            int quantity, List<int> redirectToSaleIndexes, int refundPolicy, int refundTimeLimit ,uint rewardAdjustorPointerHash, int seedOverride,
            List<VendorItemSocketOverride> socketOverrides, int sortValue, int vendorItemIndex, int visibilityScope, double weight)
        {
            Action = action;
            CategoryIndex = categoryIndex;
            CreationLevels = creationLevels;
            Currencies = currencies;
            DisplayCategory = displayCategory;
            DisplayCategoryIndex = displayCategoryIndex;
            Exclusivity = exclusivity;
            ExpirationTooltip = expirationTooltip;
            FailureIndexes = failureIndexes;
            InventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(inventoryBucketHash, "DestinyInventoryBucketDefinition");
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition");
            LicenseUnlockHash = licenseUnlockHash;
            MaximumLevel = maximumLevel;
            MinimumLevel = minimumLevel;
            OriginalCategoryIndex = originalCategoryIndex;
            PriceOverrideEnabled = priceOverrideEnabled;
            PurchasableScope = purchasableScope;
            Quantity = quantity;
            RedirectToSaleIndexes = redirectToSaleIndexes;
            RefundPolicy = refundPolicy;
            RefundTimeLimit = refundTimeLimit;
            RewardAdjustorPointer = new DefinitionHashPointer<DestinyRewardAdjusterPointerDefinition>(rewardAdjustorPointerHash, "DestinyRewardAdjusterPointerDefinition");
            SeedOverride = seedOverride;
            SocketOverrides = socketOverrides;
            SortValue = sortValue;
            VendorItemIndex = vendorItemIndex;
            VisibilityScope = visibilityScope;
            Weight = weight;
        }
    }
}
