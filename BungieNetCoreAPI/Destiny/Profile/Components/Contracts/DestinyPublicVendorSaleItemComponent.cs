using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicVendorSaleItemComponent
    {
        public int VendorItemIndex { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; }
        public int Quantity { get; }
        public ReadOnlyCollection<DestinyItemQuantity> Costs { get; }
        public DateTime? OverrideNextRefreshDate { get; }
        public bool? ApiPurchasable { get; }

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
