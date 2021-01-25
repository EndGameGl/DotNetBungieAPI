using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Progressions
{
    public class ProgressionReward
    {
        public int AcquisitionBehavior { get; }
        public string[] ClaimUnlockDisplayStrings { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public int Quantity { get; }
        public int RewardedAtProgressionLevel { get; }
        public string UiDisplayStyle { get; }

        [JsonConstructor]
        private ProgressionReward(int acquisitionBehavior, string[] claimUnlockDisplayStrings, uint itemHash, int quantity, int rewardedAtProgressionLevel, string uiDisplayStyle)
        {
            AcquisitionBehavior = acquisitionBehavior;
            ClaimUnlockDisplayStrings = claimUnlockDisplayStrings;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Quantity = quantity;
            RewardedAtProgressionLevel = rewardedAtProgressionLevel;
            UiDisplayStyle = uiDisplayStyle;
        }
    }
}
