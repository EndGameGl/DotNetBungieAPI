using NetBungieAPI.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.RewardAdjusterPointers;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorItem : IDeepEquatable<VendorItem>
    {
        public int VendorItemIndex { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public int Quantity { get; init; }
        public ReadOnlyCollection<int> FailureIndexes { get; init; }
        public ReadOnlyCollection<VendorItemQuantity> Currencies { get; init; }
        public VendorItemRefundPolicy RefundPolicy { get; init; }
        public int RefundTimeLimit { get; init; }
        public ReadOnlyCollection<VendorItemCreationLevel> CreationLevels { get; init; }
        public int DisplayCategoryIndex { get; init; }
        public int CategoryIndex { get; init; }
        public int OriginalCategoryIndex { get; init; }
        public int MinimumLevel { get; init; }
        public int MaximumLevel { get; init; }
        public VendorItemAction Action { get; init; }
        public string DisplayCategory { get; init; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; init; }
        public DestinyGatingScope VisibilityScope { get; init; }
        public DestinyGatingScope PurchasableScope { get; init; }
        public int Exclusivity { get; init; }
        public bool? IsOffer { get; init; }
        public bool? IsCRM { get; init; }
        public int SortValue { get; init; }
        public string ExpirationTooltip { get; init; }
        public ReadOnlyCollection<int> RedirectToSaleIndexes { get; init; }
        public ReadOnlyCollection<VendorItemSocketOverride> SocketOverrides { get; init; }
        public bool? IsUnpurchasable { get; init; }
        public uint LicenseUnlockHash { get; init; }
        public bool PriceOverrideEnabled { get; init; }
        public DefinitionHashPointer<DestinyRewardAdjusterPointerDefinition> RewardAdjustorPointer { get; init; }
        public int SeedOverride { get; init; }
        public double Weight { get; init; }

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
