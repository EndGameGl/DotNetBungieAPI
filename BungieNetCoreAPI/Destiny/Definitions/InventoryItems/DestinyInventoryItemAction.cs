﻿using BungieNetCoreAPI.Destiny.Definitions.RewardSheets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class DestinyInventoryItemAction
    {
        public string ActionTypeLabel { get; }
        public bool ConsumeEntireStack { get; }
        public bool DeleteOnAction { get; }
        public bool IsPositive { get; }
        public List<object> ProgressionRewards { get; }
        public uint RequiredCooldownHash { get; }
        public int RequiredCooldownSeconds { get; }
        public List<object> RequiredItems { get; }
        public uint RewardItemHash { get; }
        public DefinitionHashPointer<DestinyRewardSheetDefinition> RewardSheet { get; }
        public uint RewardSiteHash { get; }
        public bool UseOnAcquire { get; }
        public string VerbDescription { get; }
        public string VerbName { get; }

        [JsonConstructor]
        private DestinyInventoryItemAction(string actionTypeLabel, bool consumeEntireStack, bool deleteOnAction, bool isPositive, List<object> progressionRewards,
            uint requiredCooldownHash, int requiredCooldownSeconds, List<object> requiredItems, uint rewardItemHash, uint rewardSheetHash, uint rewardSiteHash,
            bool useOnAcquire, string verbDescription, string verbName)
        {
            ActionTypeLabel = actionTypeLabel;
            ConsumeEntireStack = consumeEntireStack;
            DeleteOnAction = deleteOnAction;
            IsPositive = isPositive;
            RequiredCooldownHash = requiredCooldownHash;
            RequiredCooldownSeconds = requiredCooldownSeconds;
            RewardItemHash = rewardItemHash;
            RewardSheet = new DefinitionHashPointer<DestinyRewardSheetDefinition>(rewardSheetHash, "DestinyRewardSheetDefinition") ;
            RewardSiteHash = rewardSiteHash;
            UseOnAcquire = useOnAcquire;
            VerbDescription = verbDescription;
            VerbName = verbName;

        }
    }
}
