using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// An item can have objectives on it. In practice, these are the exclusive purview of "Quest Step" items: DestinyInventoryItemDefinitions that represent a specific step in a Quest.
    /// <para/>
    /// Quest steps have 1:M objectives that we end up processing and returning in live data as DestinyQuestStatus data, and other useful information.
    /// </summary>
    public class InventoryItemObjectivesBlock : IDeepEquatable<InventoryItemObjectivesBlock>
    {      
        /// <summary>
        /// For every entry in objectiveHashes, there is a corresponding entry in this array at the same index. If the objective is meant to be associated with a specific DestinyActivityDefinition, there will be a valid hash at that index. Otherwise, it will be invalid (0).
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityDefinition>> DisplayActivities { get; }       
        /// <summary>
        /// The localized string for narrative text related to this quest step, if any.
        /// </summary>
        public string Narrative { get; }        
        /// <summary>
        /// Objectives (DestinyObjectiveDefinition) that are part of this Quest Step, in the order that they should be rendered.
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> Objectives { get; }
        /// <summary>
        /// The localized string describing an action to be performed associated with the objectives, if any.
        /// </summary>
        public string ObjectiveVerbName { get; }
        /// <summary>
        /// One entry per Objective on the item, it will have related display information.
        /// </summary>
        public ReadOnlyCollection<InventoryItemObjectivesBlockObjectiveDisplayProperties> PerObjectiveDisplayProperties { get; }
        /// <summary>
        /// A hashed value for the questTypeIdentifier, because apparently I like to be redundant.
        /// </summary>
        public uint QuestTypeHash { get; }
        /// <summary>
        /// The identifier for the type of quest being performed, if any. Not associated with any fixed definition, yet.
        /// </summary>
        public string QuestTypeIdentifier { get; }
        /// <summary>
        /// The DestinyInventoryItemDefinition representing the Quest to which this Quest Step belongs.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; }
        /// <summary>
        /// If True, all objectives must be completed for the step to be completed. If False, any one objective can be completed for the step to be completed.
        /// </summary>
        public bool RequireFullObjectiveCompletion { get; }
        public uint TimestampUnlockValueHash { get; }
        public bool UseOnObjectiveCompletion { get; }
        public uint CompletionRewardSiteHash { get; }
        public uint NextQuestStepRewardSiteHash { get; }
        public bool DisplayAsStatTracker { get; }
        public uint InhibitCompletionUnlockValueHash { get; }
        public bool IsGlobalObjectiveItem { get; }

        [JsonConstructor]
        internal InventoryItemObjectivesBlock(uint completionRewardSiteHash, uint[] displayActivityHashes, bool displayAsStatTracker,
            uint inhibitCompletionUnlockValueHash, bool isGlobalObjectiveItem, string narrative, uint nextQuestStepRewardSiteHash, uint[] objectiveHashes,
            string objectiveVerbName, InventoryItemObjectivesBlockObjectiveDisplayProperties[] perObjectiveDisplayProperties, uint questTypeHash,
            string questTypeIdentifier, uint questlineItemHash, bool requireFullObjectiveCompletion, uint timestampUnlockValueHash, bool useOnObjectiveCompletion)
        {
            CompletionRewardSiteHash = completionRewardSiteHash;
            DisplayActivities = displayActivityHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityDefinition>(DefinitionsEnum.DestinyActivityDefinition);
            DisplayAsStatTracker = displayAsStatTracker;
            InhibitCompletionUnlockValueHash = inhibitCompletionUnlockValueHash;
            IsGlobalObjectiveItem = isGlobalObjectiveItem;
            Narrative = narrative;
            NextQuestStepRewardSiteHash = nextQuestStepRewardSiteHash;
            Objectives = objectiveHashes.DefinitionsAsReadOnlyOrEmpty<DestinyObjectiveDefinition>(DefinitionsEnum.DestinyObjectiveDefinition);
            ObjectiveVerbName = objectiveVerbName;
            PerObjectiveDisplayProperties = perObjectiveDisplayProperties.AsReadOnlyOrEmpty();
            QuestTypeHash = questTypeHash;
            QuestTypeIdentifier = questTypeIdentifier;
            QuestlineItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questlineItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            RequireFullObjectiveCompletion = requireFullObjectiveCompletion;
            TimestampUnlockValueHash = timestampUnlockValueHash;
            UseOnObjectiveCompletion = useOnObjectiveCompletion;
        }

        public bool DeepEquals(InventoryItemObjectivesBlock other)
        {
            return other != null &&
                   DisplayActivities.DeepEqualsReadOnlyCollections(other.DisplayActivities) &&
                   Narrative == other.Narrative &&
                   Objectives.DeepEqualsReadOnlyCollections(other.Objectives) &&
                   ObjectiveVerbName == other.ObjectiveVerbName &&
                   PerObjectiveDisplayProperties.DeepEqualsReadOnlyCollections(other.PerObjectiveDisplayProperties) &&
                   QuestTypeHash == other.QuestTypeHash &&
                   QuestTypeIdentifier == other.QuestTypeIdentifier &&
                   QuestlineItem.DeepEquals(other.QuestlineItem) &&
                   RequireFullObjectiveCompletion == other.RequireFullObjectiveCompletion &&
                   TimestampUnlockValueHash == other.TimestampUnlockValueHash &&
                   UseOnObjectiveCompletion == other.UseOnObjectiveCompletion &&
                   CompletionRewardSiteHash == other.CompletionRewardSiteHash &&
                   NextQuestStepRewardSiteHash == other.NextQuestStepRewardSiteHash &&
                   DisplayAsStatTracker == other.DisplayAsStatTracker &&
                   InhibitCompletionUnlockValueHash == other.InhibitCompletionUnlockValueHash &&
                   IsGlobalObjectiveItem == other.IsGlobalObjectiveItem;
        }
    }
}
