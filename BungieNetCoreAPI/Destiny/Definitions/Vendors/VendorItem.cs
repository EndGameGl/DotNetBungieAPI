using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterPointers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorItem : IDeepEquatable<VendorItem>
    {
        public int VendorItemIndex { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }
        public ReadOnlyCollection<int> FailureIndexes { get; }
        public ReadOnlyCollection<VendorItemQuantity> Currencies { get; }
        public VendorItemRefundPolicy RefundPolicy { get; }
        public int RefundTimeLimit { get; }
        public ReadOnlyCollection<VendorItemCreationLevel> CreationLevels { get; }
        public int DisplayCategoryIndex { get; }
        public int CategoryIndex { get; }
        public int OriginalCategoryIndex { get; }
        public int MinimumLevel { get; }
        public int MaximumLevel { get; }
        public VendorItemAction Action { get; }
        public string DisplayCategory { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; }
        public DestinyGatingScope VisibilityScope { get; }
        public DestinyGatingScope PurchasableScope { get; }
        public int Exclusivity { get; }
        public bool? IsOffer { get; }
        public bool? IsCRM { get; }
        public int SortValue { get; }
        public string ExpirationTooltip { get; }
        public ReadOnlyCollection<int> RedirectToSaleIndexes { get; }
        public ReadOnlyCollection<VendorItemSocketOverride> SocketOverrides { get; }
        public bool? IsUnpurchasable { get; }
        public uint LicenseUnlockHash { get; }
        public bool PriceOverrideEnabled { get; }
        public DefinitionHashPointer<DestinyRewardAdjusterPointerDefinition> RewardAdjustorPointer { get; }
        public int SeedOverride { get; }
        public double Weight { get; }

        [JsonConstructor]
        internal VendorItem(VendorItemAction action, int categoryIndex, VendorItemCreationLevel[] creationLevels, VendorItemQuantity[] currencies, string displayCategory,
            int displayCategoryIndex, int exclusivity, string expirationTooltip, int[] failureIndexes, uint inventoryBucketHash, uint itemHash,
            uint licenseUnlockHash, int maximumLevel, int minimumLevel, int originalCategoryIndex, bool priceOverrideEnabled, DestinyGatingScope purchasableScope,
            int quantity, int[] redirectToSaleIndexes, VendorItemRefundPolicy refundPolicy, int refundTimeLimit, uint rewardAdjustorPointerHash, int seedOverride,
            VendorItemSocketOverride[] socketOverrides, int sortValue, int vendorItemIndex, DestinyGatingScope visibilityScope, double weight,
            bool? isOffer, bool? isCrm, bool? unpurchasable)
        {
            Action = action;
            CategoryIndex = categoryIndex;
            CreationLevels = creationLevels.AsReadOnlyOrEmpty();
            Currencies = currencies.AsReadOnlyOrEmpty();
            DisplayCategory = displayCategory;
            DisplayCategoryIndex = displayCategoryIndex;
            Exclusivity = exclusivity;
            ExpirationTooltip = expirationTooltip;
            FailureIndexes = failureIndexes.AsReadOnlyOrEmpty();
            InventoryBucket = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(inventoryBucketHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            LicenseUnlockHash = licenseUnlockHash;
            MaximumLevel = maximumLevel;
            MinimumLevel = minimumLevel;
            OriginalCategoryIndex = originalCategoryIndex;
            PriceOverrideEnabled = priceOverrideEnabled;
            PurchasableScope = purchasableScope;
            Quantity = quantity;
            RedirectToSaleIndexes = redirectToSaleIndexes.AsReadOnlyOrEmpty();
            RefundPolicy = refundPolicy;
            RefundTimeLimit = refundTimeLimit;
            RewardAdjustorPointer = new DefinitionHashPointer<DestinyRewardAdjusterPointerDefinition>(rewardAdjustorPointerHash, DefinitionsEnum.DestinyRewardAdjusterPointerDefinition);
            SeedOverride = seedOverride;
            SocketOverrides = socketOverrides.AsReadOnlyOrEmpty();
            SortValue = sortValue;
            VendorItemIndex = vendorItemIndex;
            VisibilityScope = visibilityScope;
            Weight = weight;
            IsOffer = isOffer;
            IsCRM = isCrm;
            IsUnpurchasable = unpurchasable;
        }

        public bool DeepEquals(VendorItem other)
        {
            return other != null &&
                   VendorItemIndex == other.VendorItemIndex &&
                   Item.DeepEquals(other.Item) &&
                   Quantity == other.Quantity &&
                   FailureIndexes.DeepEqualsReadOnlySimpleCollection(other.FailureIndexes) &&
                   Currencies.DeepEqualsReadOnlyCollections(other.Currencies) &&
                   RefundPolicy == other.RefundPolicy &&
                   RefundTimeLimit == other.RefundTimeLimit &&
                   CreationLevels.DeepEqualsReadOnlyCollections(other.CreationLevels) &&
                   DisplayCategoryIndex == other.DisplayCategoryIndex &&
                   CategoryIndex == other.CategoryIndex &&
                   OriginalCategoryIndex == other.OriginalCategoryIndex &&
                   MinimumLevel == other.MinimumLevel &&
                   MaximumLevel == other.MaximumLevel &&
                   Action.DeepEquals(other.Action) &&
                   DisplayCategory == other.DisplayCategory &&
                   InventoryBucket.DeepEquals(other.InventoryBucket) &&
                   VisibilityScope == other.VisibilityScope &&
                   PurchasableScope == other.PurchasableScope &&
                   Exclusivity == other.Exclusivity &&
                   IsOffer == other.IsOffer &&
                   IsCRM == other.IsCRM &&
                   SortValue == other.SortValue &&
                   ExpirationTooltip == other.ExpirationTooltip &&
                   RedirectToSaleIndexes.DeepEqualsReadOnlySimpleCollection(other.RedirectToSaleIndexes) &&
                   SocketOverrides.DeepEqualsReadOnlyCollections(other.SocketOverrides) &&
                   IsUnpurchasable == other.IsUnpurchasable &&
                   LicenseUnlockHash == other.LicenseUnlockHash &&
                   PriceOverrideEnabled == other.PriceOverrideEnabled &&
                   RewardAdjustorPointer.DeepEquals(other.RewardAdjustorPointer) &&
                   SeedOverride == other.SeedOverride &&
                   Weight == other.Weight;
        }
    }
}
