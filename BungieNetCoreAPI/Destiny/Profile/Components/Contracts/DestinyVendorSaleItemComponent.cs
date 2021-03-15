using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyVendorSaleItemComponent
    {
        public VendorItemStatus SaleStatus { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>> RequiredUnlocks { get; }
        public ReadOnlyCollection<DestinyUnlockStatus> UnlockStatuses { get; }
        public ReadOnlyCollection<int> FailureIndexes { get; }
        public DestinyVendorItemState Augments { get; }
        public int VendorItemIndex { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; }
        public int Quantity { get; }
        public ReadOnlyCollection<DestinyItemQuantity> Costs { get; }
        public DateTime? OverrideNextRefreshDate { get; }
        public bool? ApiPurchasable { get; }

        [JsonConstructor]
        internal DestinyVendorSaleItemComponent(VendorItemStatus saleStatus, uint[] requiredUnlocks, DestinyUnlockStatus[] unlockStatuses,
            int[] failureIndexes, DestinyVendorItemState augments, int vendorItemIndex, uint itemHash, uint? overrideStyleItemHash,
            int quantity, DestinyItemQuantity[] costs, DateTime? overrideNextRefreshDate, bool? apiPurchasable)
        {
            SaleStatus = saleStatus;
            RequiredUnlocks = requiredUnlocks.DefinitionsAsReadOnlyOrEmpty<DestinyUnlockDefinition>(DefinitionsEnum.DestinyUnlockDefinition);
            UnlockStatuses = unlockStatuses.AsReadOnlyOrEmpty();
            FailureIndexes = failureIndexes.AsReadOnlyOrEmpty();
            Augments = augments;
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
