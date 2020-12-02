using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.Classes;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using BungieNetCoreAPI.Destiny.Definitions.ItemCategories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    [DestinyDefinition("DestinyInventoryItemDefinition")]
    public class DestinyInventoryItemDefinition : DestinyDefinition
    {
        public uint AcquireRewardSiteHash { get; }
        public uint AcquireUnlockHash { get; }
        public InventoryItemAction Action { get; }
        public bool AllowActions { get; }
        public DestinyColor BackgroundColor { get; }
        public DestinyBreakerTypes BreakerType { get; }
        public DestinyClassType ClassType { get; }
        public DestinyDamageTypes DefaultDamageType { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string DisplaySource { get; }
        public bool DoesPostmasterPullHaveSideEffects { get; }
        public bool Equippable { get; }
        public InventoryItemEquippingBlock EquippingBlock { get; }
        public string IconWatermark { get; }
        public string IconWatermarkShelved { get; }
        public InventoryItemInventoryBlock Inventory { get; }
        public List<InventoryItemInvestmentStat> InvestmentStats { get; }
        public bool IsWrapper { get; }
        public List<DefinitionHashPointer<DestinyItemCategoryDefinition>> ItemCategories { get; }
        public int ItemSubType { get; }
        public int ItemType { get; }
        public string ItemTypeAndTierDisplayName { get; }
        public string ItemTypeDisplayName { get; }
        public bool NonTransferrable { get; }
        [JsonConstructor]
        private DestinyInventoryItemDefinition(uint acquireRewardSiteHash, uint acquireUnlockHash, bool allowActions, DestinyColor backgroundColor, InventoryItemAction action,
            DestinyBreakerTypes breakerType, DestinyClassType classType, DestinyDefinitionDisplayProperties displayProperties, DestinyDamageTypes defaultDamageType, string displaySource,
            bool doesPostmasterPullHaveSideEffects, bool equippable, InventoryItemEquippingBlock equippingBlock, string iconWatermark, string iconWatermarkShelved,
            InventoryItemInventoryBlock inventory, List<InventoryItemInvestmentStat> investmentStats, bool isWrapper, List<uint> itemCategoryHashes, int itemSubType,
            int itemType, string itemTypeAndTierDisplayName, string itemTypeDisplayName, bool nonTransferrable,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            AcquireRewardSiteHash = acquireRewardSiteHash;
            AcquireUnlockHash = acquireUnlockHash;
            AllowActions = allowActions;
            BackgroundColor = backgroundColor;
            Action = action;
            DisplayProperties = displayProperties;
            BreakerType = breakerType;
            ClassType = classType;
            DefaultDamageType = defaultDamageType;
            DisplaySource = displaySource;
            DoesPostmasterPullHaveSideEffects = doesPostmasterPullHaveSideEffects;
            Equippable = equippable;
            EquippingBlock = equippingBlock;
            IconWatermark = iconWatermark;
            IconWatermarkShelved = iconWatermarkShelved;
            Inventory = inventory;
            InvestmentStats = investmentStats;
            IsWrapper = isWrapper;
            ItemCategories = new List<DefinitionHashPointer<DestinyItemCategoryDefinition>>();
            if (itemCategoryHashes != null)
            {
                foreach (var itemCategoryHash in itemCategoryHashes)
                {
                    ItemCategories.Add(new DefinitionHashPointer<DestinyItemCategoryDefinition>(itemCategoryHash, "DestinyItemCategoryDefinition"));
                }
            }
            ItemSubType = itemSubType;
            ItemType = itemType;
            ItemTypeAndTierDisplayName = itemTypeAndTierDisplayName;
            ItemTypeDisplayName = itemTypeDisplayName;
            NonTransferrable = nonTransferrable;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
