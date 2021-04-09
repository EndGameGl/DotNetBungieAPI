using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorItemDefinition : IDeepEquatable<DestinyVendorItemDefinition>
    {
        [JsonPropertyName("vendorItemIndex")]
        public int VendorItemIndex { get; init; }
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("quantity")]
        public int Quantity { get; init; }
        [JsonPropertyName("failureIndexes")]
        public ReadOnlyCollection<int> FailureIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("currencies")]
        public ReadOnlyCollection<DestinyItemQuantity> Currencies { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
        [JsonPropertyName("refundPolicy")]
        public DestinyVendorItemRefundPolicy RefundPolicy { get; init; }
        [JsonPropertyName("refundTimeLimit")]
        public int RefundTimeLimit { get; init; }
        [JsonPropertyName("creationLevels")]
        public ReadOnlyCollection<DestinyItemCreationEntryLevelDefinition> CreationLevels { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemCreationEntryLevelDefinition>();
        [JsonPropertyName("displayCategoryIndex")]
        public int DisplayCategoryIndex { get; init; }
        [JsonPropertyName("categoryIndex")]
        public int CategoryIndex { get; init; }
        [JsonPropertyName("originalCategoryIndex")]
        public int OriginalCategoryIndex { get; init; }
        [JsonPropertyName("minimumLevel")]
        public int MinimumLevel { get; init; }
        [JsonPropertyName("maximumLevel")]
        public int MaximumLevel { get; init; }
        [JsonPropertyName("action")]
        public DestinyVendorSaleItemActionBlockDefinition Action { get; init; }
        [JsonPropertyName("displayCategory")]
        public string DisplayCategory { get; init; }
        [JsonPropertyName("inventoryBucketHash")]
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> InventoryBucket { get; init; } = DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;
        [JsonPropertyName("visibilityScope")]
        public DestinyGatingScope VisibilityScope { get; init; }
        [JsonPropertyName("purchasableScope")]
        public DestinyGatingScope PurchasableScope { get; init; }
        [JsonPropertyName("exclusivity")]
        public int Exclusivity { get; init; }
        [JsonPropertyName("isOffer")]
        public bool? IsOffer { get; init; }
        [JsonPropertyName("isCrm")]
        public bool? IsCRM { get; init; }
        [JsonPropertyName("sortValue")]
        public int SortValue { get; init; }
        [JsonPropertyName("expirationTooltip")]
        public string ExpirationTooltip { get; init; }
        [JsonPropertyName("redirectToSaleIndexes")]
        public ReadOnlyCollection<int> RedirectToSaleIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("socketOverrides")]
        public ReadOnlyCollection<DestinyVendorItemSocketOverride> SocketOverrides { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorItemSocketOverride>();
        [JsonPropertyName("unpurchasable")]
        public bool? IsUnpurchasable { get; init; }

        public bool DeepEquals(DestinyVendorItemDefinition other)
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
                   IsUnpurchasable == other.IsUnpurchasable;
        }
    }
}
