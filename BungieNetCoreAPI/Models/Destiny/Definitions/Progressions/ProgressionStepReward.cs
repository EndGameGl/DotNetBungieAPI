using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Progressions
{
    public class ProgressionStepReward : IDeepEquatable<ProgressionStepReward>
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public long? ItemInstanceId { get; init; }
        public int Quantity { get; init; }
        public ReadOnlyCollection<string> ClaimUnlockDisplayStrings { get; init; }
        public string UiDisplayStyle { get; init; }
        public ProgressionRewardItemAcquisitionBehavior AcquisitionBehavior { get; init; }
        public int RewardedAtProgressionLevel { get; init; }

        [JsonConstructor]
        internal ProgressionStepReward(uint itemHash, long? itemInstanceId, int quantity, string[] claimUnlockDisplayStrings, string uiDisplayStyle,
            ProgressionRewardItemAcquisitionBehavior acquisitionBehavior, int rewardedAtProgressionLevel)
        {
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            ItemInstanceId = itemInstanceId;
            Quantity = quantity;
            ClaimUnlockDisplayStrings = claimUnlockDisplayStrings.AsReadOnlyOrEmpty();
            UiDisplayStyle = uiDisplayStyle;
            AcquisitionBehavior = acquisitionBehavior;
            RewardedAtProgressionLevel = rewardedAtProgressionLevel;
        }

        public bool DeepEquals(ProgressionStepReward other)
        {
            return other != null &&
                   Item.DeepEquals(other.Item) &&
                   ItemInstanceId == other.ItemInstanceId &&
                   Quantity == other.Quantity &&
                   ClaimUnlockDisplayStrings.DeepEqualsReadOnlySimpleCollection(other.ClaimUnlockDisplayStrings) &&
                   UiDisplayStyle == other.UiDisplayStyle &&
                   AcquisitionBehavior == other.AcquisitionBehavior &&
                   RewardedAtProgressionLevel == other.RewardedAtProgressionLevel;
        }
    }
}
