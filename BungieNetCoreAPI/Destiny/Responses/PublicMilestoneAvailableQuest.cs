using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Responses
{
    public class PublicMilestoneAvailableQuest
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; }

        [JsonConstructor]
        private PublicMilestoneAvailableQuest(uint questItemHash)
        {
            QuestItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
