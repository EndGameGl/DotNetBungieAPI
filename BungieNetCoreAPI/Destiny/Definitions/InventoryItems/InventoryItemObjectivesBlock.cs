using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemObjectivesBlock
    {
        public uint CompletionRewardSiteHash { get; }
        public List<DefinitionHashPointer<DestinyActivityDefinition>> DisplayActivities { get; }
        public bool DisplayAsStatTracker { get; }
        public uint InhibitCompletionUnlockValueHash { get; }
        public bool IsGlobalObjectiveItem { get; }
        public string Narrative { get; }
        public uint NextQuestStepRewardSiteHash { get; }
        public List<DefinitionHashPointer<DestinyObjectiveDefinition>> Objectives { get; }
        public string ObjectiveVerbName { get; }
        public List<InventoryItemObjectivesBlockObjectiveDisplayProperties> PerObjectiveDisplayProperties { get; }
        public uint QuestTypeHash { get; }
        public string QuestTypeIdentifier { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; }
        public bool RequireFullObjectiveCompletion { get; }
        public uint TimestampUnlockValueHash { get; }
        public bool UseOnObjectiveCompletion { get; }

        [JsonConstructor]
        private InventoryItemObjectivesBlock(uint completionRewardSiteHash, List<uint> displayActivityHashes, bool displayAsStatTracker,
            uint inhibitCompletionUnlockValueHash, bool isGlobalObjectiveItem, string narrative, uint nextQuestStepRewardSiteHash, List<uint> objectiveHashes,
            string objectiveVerbName, List<InventoryItemObjectivesBlockObjectiveDisplayProperties> perObjectiveDisplayProperties, uint questTypeHash,
            string questTypeIdentifier, uint questlineItemHash, bool requireFullObjectiveCompletion, uint timestampUnlockValueHash, bool useOnObjectiveCompletion)
        {
            CompletionRewardSiteHash = completionRewardSiteHash;
            DisplayActivities = new List<DefinitionHashPointer<DestinyActivityDefinition>>();
            if (displayActivityHashes != null)
            {
                foreach (var displayActivityHash in displayActivityHashes)
                {
                    DisplayActivities.Add(new DefinitionHashPointer<DestinyActivityDefinition>(displayActivityHash, "DestinyActivityDefinition"));
                } 
            }
            DisplayAsStatTracker = displayAsStatTracker;
            InhibitCompletionUnlockValueHash = inhibitCompletionUnlockValueHash;
            IsGlobalObjectiveItem = isGlobalObjectiveItem;
            Narrative = narrative;
            NextQuestStepRewardSiteHash = nextQuestStepRewardSiteHash;
            Objectives = new List<DefinitionHashPointer<DestinyObjectiveDefinition>>();
            if (objectiveHashes != null)
            {
                foreach (var objectiveHash in objectiveHashes)
                {
                    Objectives.Add(new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, "DestinyObjectiveDefinition"));
                }
            }
            ObjectiveVerbName = objectiveVerbName;
            PerObjectiveDisplayProperties = perObjectiveDisplayProperties;
            QuestTypeHash = questTypeHash;
            QuestTypeIdentifier = questTypeIdentifier;
            QuestlineItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questlineItemHash, "DestinyInventoryItemDefinition");
            RequireFullObjectiveCompletion = requireFullObjectiveCompletion;
            TimestampUnlockValueHash = timestampUnlockValueHash;
            UseOnObjectiveCompletion = useOnObjectiveCompletion;
        }
    }
}
