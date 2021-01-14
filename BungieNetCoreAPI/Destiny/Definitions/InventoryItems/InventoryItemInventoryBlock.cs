using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using BungieNetCoreAPI.Destiny.Definitions.ItemTierTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemInventoryBlock
    {
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; }
        public string ExpirationTooltip { get; }
        public string ExpiredInActivityMessage { get; }
        public string ExpiredInOrbitMessage { get; }
        public bool IsInstanceItem { get; }
        public int MaxStackSize { get; }
        public bool NonTransferrableOriginal { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> RecoveryBucketType { get; }
        public bool SuppressExpirationWhenObjectivesComplete { get; }
        public ItemTierType TierTypeEnumValue { get; }
        public DefinitionHashPointer<DestinyItemTierTypeDefinition> TierType { get; }
        public string TierTypeName { get; }
        public List<object> Perks { get; }


        [JsonConstructor]
        private InventoryItemInventoryBlock(uint bucketTypeHash, string expirationTooltip, string expiredInActivityMessage, string expiredInOrbitMessage, bool isInstanceItem,
            int maxStackSize, bool nonTransferrableOriginal, uint recoveryBucketTypeHash, bool suppressExpirationWhenObjectivesComplete, ItemTierType tierType, uint tierTypeHash,
            string tierTypeName)
        {
            BucketType = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketTypeHash, "DestinyInventoryBucketDefinition");
            ExpirationTooltip = expirationTooltip;
            ExpiredInActivityMessage = expiredInActivityMessage;
            ExpiredInOrbitMessage = expiredInOrbitMessage;
            IsInstanceItem = isInstanceItem;
            MaxStackSize = maxStackSize;
            NonTransferrableOriginal = nonTransferrableOriginal;
            RecoveryBucketType = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(recoveryBucketTypeHash, "DestinyInventoryBucketDefinition");
            SuppressExpirationWhenObjectivesComplete = suppressExpirationWhenObjectivesComplete;
            TierTypeEnumValue = tierType;
            TierType = new DefinitionHashPointer<DestinyItemTierTypeDefinition>(tierTypeHash, "DestinyItemTierTypeDefinition");
            TierTypeName = tierTypeName;
        }
    }
}
