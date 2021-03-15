using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.Destinations;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneQuest : IDeepEquatable<MilestoneQuest>
    {
        /// <summary>
        /// The individual quests may have different definitions from the overall milestone: if there's a specific active quest, use these displayProperties instead of that of the overall DestinyMilestoneDefinition.
        /// </summary>
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The item representing this Milestone quest. 
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; }
        /// <summary>
        /// The rewards you will get for completing this quest, as best as we could extract them from our data. Sometimes, it'll be a decent amount of data. Sometimes, it's going to be sucky. Sorry.
        /// </summary>
        public MilestoneQuestRewardItems QuestRewards { get; }
        /// <summary>
        /// If populated, this image can be shown instead of the generic milestone's image when this quest is live, or it can be used to show a background image for the quest itself that differs from that of the Activity or the Milestone.
        /// </summary>
        public string OverrideImage { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, MilestoneQuestActivity> Activities { get; }

        [JsonConstructor]
        internal MilestoneQuest(DestinyDefinitionDisplayProperties displayProperties, uint questItemHash, MilestoneQuestRewardItems questRewards,
            string overrideImage, uint? destinationHash, Dictionary<uint, MilestoneQuestActivity> activities)
        {
            DisplayProperties = displayProperties;
            QuestItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            QuestRewards = questRewards;
            OverrideImage = overrideImage;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            Activities = activities.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyActivityDefinition, MilestoneQuestActivity>(DefinitionsEnum.DestinyActivityDefinition);
        }

        public bool DeepEquals(MilestoneQuest other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   QuestItem.DeepEquals(other.QuestItem) &&
                   QuestRewards.DeepEquals(other.QuestRewards) &&
                   OverrideImage == other.OverrideImage &&
                   Destination.DeepEquals(other.Destination) &&
                   Activities.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.Activities);
        }
    }
}
