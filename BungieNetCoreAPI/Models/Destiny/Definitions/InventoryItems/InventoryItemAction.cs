using NetBungieAPI.Destiny.Definitions.RewardSheets;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// If an item can have an action performed on it (like "Dismantle"), it will be defined here if you care.
    /// </summary>
    public class InventoryItemAction : IDeepEquatable<InventoryItemAction>
    {
        /// <summary>
        /// If the action has an overlay screen associated with it, this is the name of that screen. Unfortunately, we cannot return the screen's data itself.
        /// </summary>
        public string OverlayScreenName { get; init; }
        /// <summary>
        /// The icon associated with the overlay screen for the action, if any.
        /// </summary>
        public string OverlayIcon { get; init; }
        /// <summary>
        /// The internal identifier for the action.
        /// </summary>
        public string ActionTypeLabel { get; init; }
        /// <summary>
        /// If true, the entire stack is deleted when the action completes.
        /// </summary>
        public bool ConsumeEntireStack { get; init; }
        /// <summary>
        /// If true, the item is deleted when the action completes.
        /// </summary>
        public bool DeleteOnAction { get; init; }
        /// <summary>
        /// The content has this property, however it's not entirely clear how it is used.
        /// </summary>
        public bool IsPositive { get; init; }
        /// <summary>
        /// If performing this action earns you Progression, this is the list of progressions and values granted for those progressions by performing this action.
        /// </summary>
        public ReadOnlyCollection<InventoryItemActionProgressionReward> ProgressionRewards { get; init; }
        /// <summary>
        /// The identifier hash for the Cooldown associated with this action. We have not pulled this data yet for you to have more data to use for cooldowns.
        /// </summary>
        public uint RequiredCooldownHash { get; init; }
        /// <summary>
        /// The number of seconds to delay before allowing this action to be performed again.
        /// </summary>
        public int RequiredCooldownSeconds { get; init; }
        /// <summary>
        /// Theoretically, an item could have a localized string for a hint about the location in which the action should be performed. In practice, no items yet have this property.
        /// </summary>
        public string RequiredLocation { get; init; }
        public ReadOnlyCollection<InventoryItemActionRequiredItem> RequiredItems { get; init; }       
        /// <summary>
        /// If true, this action will be performed as soon as you earn this item. Some rewards work this way, providing you a single item to pick up from a reward-granting vendor in-game and then immediately consuming itself to provide you multiple items.
        /// </summary>
        public bool UseOnAcquire { get; init; }
        /// <summary>
        /// Localized text describing the action being performed.
        /// </summary>
        public string VerbDescription { get; init; }
        /// <summary>
        /// Localized text for the verb of the action being performed.
        /// </summary>
        public string VerbName { get; init; }
        public uint RewardItemHash { get; init; }
        public DefinitionHashPointer<DestinyRewardSheetDefinition> RewardSheet { get; init; }
        public uint RewardSiteHash { get; init; }

        [JsonConstructor]
        internal InventoryItemAction(string actionTypeLabel, bool consumeEntireStack, bool deleteOnAction, bool isPositive, InventoryItemActionProgressionReward[] progressionRewards,
            uint requiredCooldownHash, int requiredCooldownSeconds, InventoryItemActionRequiredItem[] requiredItems, uint rewardItemHash, uint rewardSheetHash, uint rewardSiteHash,
            bool useOnAcquire, string verbDescription, string verbName, string overlayScreenName, string overlayIcon, string requiredLocation)
        {
            ActionTypeLabel = actionTypeLabel;
            ConsumeEntireStack = consumeEntireStack;
            DeleteOnAction = deleteOnAction;
            IsPositive = isPositive;
            RequiredCooldownHash = requiredCooldownHash;
            RequiredCooldownSeconds = requiredCooldownSeconds;
            RewardItemHash = rewardItemHash;
            RewardSheet = new DefinitionHashPointer<DestinyRewardSheetDefinition>(rewardSheetHash, DefinitionsEnum.DestinyRewardSheetDefinition);
            RewardSiteHash = rewardSiteHash;
            UseOnAcquire = useOnAcquire;
            VerbDescription = verbDescription;
            VerbName = verbName;
            OverlayScreenName = overlayScreenName;
            OverlayIcon = overlayIcon;
            RequiredLocation = requiredLocation;
            RequiredItems = requiredItems.AsReadOnlyOrEmpty();
            ProgressionRewards = progressionRewards.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(InventoryItemAction other)
        {
            return other != null &&
                   OverlayScreenName == other.OverlayScreenName &&
                   OverlayIcon == other.OverlayIcon &&
                   ActionTypeLabel == other.ActionTypeLabel &&
                   ConsumeEntireStack == other.ConsumeEntireStack &&
                   DeleteOnAction == other.DeleteOnAction &&
                   IsPositive == other.IsPositive &&
                   ProgressionRewards.DeepEqualsReadOnlyCollections(other.ProgressionRewards) &&
                   RequiredCooldownHash == other.RequiredCooldownHash &&
                   RequiredCooldownSeconds == other.RequiredCooldownSeconds &&
                   RequiredLocation == other.RequiredLocation &&
                   RequiredItems.DeepEqualsReadOnlyCollections(other.RequiredItems) &&
                   UseOnAcquire == other.UseOnAcquire &&
                   VerbDescription == other.VerbDescription &&
                   VerbName == other.VerbName &&
                   RewardItemHash == other.RewardItemHash &&
                   RewardSheet.DeepEquals(other.RewardSheet) &&
                   RewardSiteHash == other.RewardSiteHash;
        }
    }
}
