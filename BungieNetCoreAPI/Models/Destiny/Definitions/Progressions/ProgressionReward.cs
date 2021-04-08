using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Progressions
{
    public class ProgressionReward : IDeepEquatable<ProgressionReward>
    {
        public ProgressionRewardItemAcquisitionBehavior AcquisitionBehavior { get; init; }
        public ReadOnlyCollection<string> ClaimUnlockDisplayStrings { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; }
        public int Quantity { get; init; }
        public int RewardedAtProgressionLevel { get; init; }
        public string UiDisplayStyle { get; init; }
        public long? ItemInstanceId { get; init; }

        [JsonConstructor]
        internal ProgressionReward(ProgressionRewardItemAcquisitionBehavior acquisitionBehavior, string[] claimUnlockDisplayStrings, uint itemHash, 
            int quantity, int rewardedAtProgressionLevel, string uiDisplayStyle, long? itemInstanceId)
        {
            AcquisitionBehavior = acquisitionBehavior;
            ClaimUnlockDisplayStrings = claimUnlockDisplayStrings.AsReadOnlyOrEmpty();
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            RewardedAtProgressionLevel = rewardedAtProgressionLevel;
            UiDisplayStyle = uiDisplayStyle;
            ItemInstanceId = itemInstanceId;
        }

        public bool DeepEquals(ProgressionReward other)
        {
            return other != null &&
                   AcquisitionBehavior == other.AcquisitionBehavior &&
                   ClaimUnlockDisplayStrings.DeepEqualsReadOnlySimpleCollection(other.ClaimUnlockDisplayStrings) &&
                   Item.DeepEquals(other.Item) &&
                   Quantity == other.Quantity &&
                   RewardedAtProgressionLevel == other.RewardedAtProgressionLevel &&
                   UiDisplayStyle == other.UiDisplayStyle &&
                   ItemInstanceId == other.ItemInstanceId;
        }
    }
}
