using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Unlocks;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyVendorSaleItemComponent
    {
        [JsonPropertyName("saleStatus")] public VendorItemStatus SaleStatus { get; init; }

        [JsonPropertyName("requiredUnlocks")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>> RequiredUnlocks { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>>();

        [JsonPropertyName("unlockStatuses")]
        public ReadOnlyCollection<DestinyUnlockStatus> UnlockStatuses { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyUnlockStatus>();

        [JsonPropertyName("failureIndexes")]
        public ReadOnlyCollection<int> FailureIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        [JsonPropertyName("augments")] public DestinyVendorItemState Augments { get; init; }

        [JsonPropertyName("itemValueVisibility")]
        public ReadOnlyCollection<bool> ItemValueVisibility { get; init; } = Defaults.EmptyReadOnlyCollection<bool>();

        [JsonPropertyName("vendorItemIndex")] public int VendorItemIndex { get; init; }

        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("overrideStyleItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("quantity")] public int Quantity { get; init; }

        [JsonPropertyName("costs")]
        public ReadOnlyCollection<DestinyItemQuantity> Costs { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();

        [JsonPropertyName("overrideNextRefreshDate")]
        public DateTime? OverrideNextRefreshDate { get; init; }

        [JsonPropertyName("apiPurchasable")] public bool? ApiPurchasable { get; init; }
    }
}