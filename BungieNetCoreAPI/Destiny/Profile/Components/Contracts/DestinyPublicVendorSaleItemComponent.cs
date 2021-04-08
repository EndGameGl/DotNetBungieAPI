using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicVendorSaleItemComponent
    {
        public int VendorItemIndex { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; init; }
        public int Quantity { get; init; }
        public ReadOnlyCollection<DestinyItemQuantity> Costs { get; init; }
        public DateTime? OverrideNextRefreshDate { get; init; }
        public bool? ApiPurchasable { get; init; }

        [JsonConstructor]
        internal DestinyPublicVendorSaleItemComponent(int vendorItemIndex, uint itemHash, uint? overrideStyleItemHash, int quantity, DestinyItemQuantity[] costs,
            DateTime? overrideNextRefreshDate, bool? apiPurchasable)
        {
            VendorItemIndex = vendorItemIndex;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            OverrideStyleItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(overrideStyleItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            Costs = costs.AsReadOnlyOrEmpty();
            OverrideNextRefreshDate = overrideNextRefreshDate;
            ApiPurchasable = apiPurchasable;
        }
    }
}
