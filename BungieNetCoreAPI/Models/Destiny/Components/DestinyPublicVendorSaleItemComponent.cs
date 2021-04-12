using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyPublicVendorSaleItemComponent
    {
        [JsonPropertyName("vendorItemIndex")]
        public int VendorItemIndex { get; init; }
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("overrideStyleItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("quantity")]
        public int Quantity { get; init; }
        [JsonPropertyName("costs")]
        public ReadOnlyCollection<DestinyItemQuantity> Costs { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
        [JsonPropertyName("overrideNextRefreshDate")]
        public DateTime? OverrideNextRefreshDate { get; init; }
        [JsonPropertyName("apiPurchasable")]
        public bool? ApiPurchasable { get; init; }
    }
}
