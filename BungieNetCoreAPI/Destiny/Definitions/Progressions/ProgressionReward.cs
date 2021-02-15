using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Progressions
{
    public class ProgressionReward : IDeepEquatable<ProgressionReward>
    {
        public ProgressionRewardItemAcquisitionBehavior AcquisitionBehavior { get; }
        public ReadOnlyCollection<string> ClaimUnlockDisplayStrings { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }
        public int RewardedAtProgressionLevel { get; }
        public string UiDisplayStyle { get; }
        public long? ItemInstanceId { get; }

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
