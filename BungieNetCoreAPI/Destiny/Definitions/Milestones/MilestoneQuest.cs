using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneQuest
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; }
        public MilestoneQuestRewardItems QuestRewards { get; }

        [JsonConstructor]
        private MilestoneQuest(DestinyDefinitionDisplayProperties displayProperties, uint questItemHash, MilestoneQuestRewardItems questRewards)
        {
            DisplayProperties = displayProperties;
            QuestItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questItemHash, "DestinyInventoryItemDefinition");
            QuestRewards = questRewards;
        }
    }
}
