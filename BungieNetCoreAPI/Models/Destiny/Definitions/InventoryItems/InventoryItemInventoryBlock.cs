using NetBungieAPI.Destiny.Definitions.InventoryBuckets;
using NetBungieAPI.Destiny.Definitions.ItemTierTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// If the item can exist in an inventory - the overwhelming majority of them can and do - then this is the basic properties regarding the item's relationship with the inventory.
    /// </summary>
    public class InventoryItemInventoryBlock : IDeepEquatable<InventoryItemInventoryBlock>
    {
        /// <summary>
        /// If this string is populated, you can't have more than one stack with this label in a given inventory. Note that this is different from the equipping block's unique label, which is used for equipping uniqueness.
        /// </summary>
        public string StackUniqueLabel { get; init; }
        /// <summary>
        /// The DestinyInventoryBucketDefinition to which this item belongs.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; init; }
        /// <summary>
        /// The tooltip message to show, if any, when the item expires.
        /// </summary>
        public string ExpirationTooltip { get; init; }
        /// <summary>
        /// If the item expires while playing in an activity, we show a different message.
        /// </summary>
        public string ExpiredInActivityMessage { get; init; }
        /// <summary>
        /// If the item expires in orbit, we show a... more different message.
        /// </summary>
        public string ExpiredInOrbitMessage { get; init; }
        /// <summary>
        /// If TRUE, this item is instanced. Otherwise, it is a generic item that merely has a quantity in a stack (like Glimmer).
        /// </summary>
        public bool IsInstanceItem { get; init; }
        /// <summary>
        /// The maximum quantity of this item that can exist in a stack.
        /// </summary>
        public int MaxStackSize { get; init; }
        public bool NonTransferrableOriginal { get; init; }
        /// <summary>
        /// If the item is picked up by the lost loot queue, this is the DestinyInventoryBucketDefinition into which it will be placed.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> RecoveryBucketType { get; init; }
        public bool SuppressExpirationWhenObjectivesComplete { get; init; }
        /// <summary>
        /// The enumeration matching the tier type of the item to known values, again for convenience sake.
        /// </summary>
        public ItemTierType TierTypeEnumValue { get; init; }
        /// <summary>
        /// Tier Type of the item, use to look up its DestinyItemTierTypeDefinition if you need to show localized data for the item's tier.
        /// </summary>
        public DefinitionHashPointer<DestinyItemTierTypeDefinition> TierType { get; init; }
        /// <summary>
        /// The localized name of the tier type, which is a useful shortcut so you don't have to look up the definition every time. However, it's mostly a holdover from days before we had a DestinyItemTierTypeDefinition to refer to.
        /// </summary>
        public string TierTypeName { get; init; }

        [JsonConstructor]
        internal InventoryItemInventoryBlock(uint bucketTypeHash, string expirationTooltip, string expiredInActivityMessage, string expiredInOrbitMessage, bool isInstanceItem,
            int maxStackSize, bool nonTransferrableOriginal, uint recoveryBucketTypeHash, bool suppressExpirationWhenObjectivesComplete, ItemTierType tierType, uint tierTypeHash,
            string tierTypeName, string stackUniqueLabel)
        {
            BucketType = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketTypeHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            ExpirationTooltip = expirationTooltip;
            ExpiredInActivityMessage = expiredInActivityMessage;
            ExpiredInOrbitMessage = expiredInOrbitMessage;
            IsInstanceItem = isInstanceItem;
            MaxStackSize = maxStackSize;
            NonTransferrableOriginal = nonTransferrableOriginal;
            RecoveryBucketType = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(recoveryBucketTypeHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            SuppressExpirationWhenObjectivesComplete = suppressExpirationWhenObjectivesComplete;
            TierTypeEnumValue = tierType;
            TierType = new DefinitionHashPointer<DestinyItemTierTypeDefinition>(tierTypeHash, DefinitionsEnum.DestinyItemTierTypeDefinition);
            TierTypeName = tierTypeName;
            StackUniqueLabel = stackUniqueLabel;
        }

        public bool DeepEquals(InventoryItemInventoryBlock other)
        {
            return other != null &&
                   StackUniqueLabel == other.StackUniqueLabel &&
                   BucketType.DeepEquals(other.BucketType) &&
                   ExpirationTooltip == other.ExpirationTooltip &&
                   ExpiredInActivityMessage == other.ExpiredInActivityMessage &&
                   ExpiredInOrbitMessage == other.ExpiredInOrbitMessage &&
                   IsInstanceItem == other.IsInstanceItem &&
                   MaxStackSize == other.MaxStackSize &&
                   NonTransferrableOriginal == other.NonTransferrableOriginal &&
                   RecoveryBucketType.DeepEquals(other.RecoveryBucketType) &&
                   SuppressExpirationWhenObjectivesComplete == other.SuppressExpirationWhenObjectivesComplete &&
                   TierTypeEnumValue == other.TierTypeEnumValue &&
                   TierType.DeepEquals(other.TierType) &&
                   TierTypeName == other.TierTypeName;
        }
    }
}
