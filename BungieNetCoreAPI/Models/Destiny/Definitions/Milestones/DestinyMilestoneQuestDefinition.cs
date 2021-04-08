using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneQuestDefinition : IDeepEquatable<DestinyMilestoneQuestDefinition>
    {
        /// <summary>
        /// The item representing this Milestone quest. 
        /// </summary>
        [JsonPropertyName("questItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        /// <summary>
        /// The individual quests may have different definitions from the overall milestone: if there's a specific active quest, use these displayProperties instead of that of the overall DestinyMilestoneDefinition.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// If populated, this image can be shown instead of the generic milestone's image when this quest is live, or it can be used to show a background image for the quest itself that differs from that of the Activity or the Milestone.
        /// </summary>
        [JsonPropertyName("overrideImage")]
        public string OverrideImage { get; init; }
        /// <summary>
        /// The rewards you will get for completing this quest, as best as we could extract them from our data. Sometimes, it'll be a decent amount of data. Sometimes, it's going to be sucky. Sorry.
        /// </summary>
        [JsonPropertyName("questRewards")]
        public DestinyMilestoneQuestRewardsDefinition QuestRewards { get; init; }
        [JsonPropertyName("activities")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, DestinyMilestoneActivityDefinition> Activities { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, DestinyMilestoneActivityDefinition>();
        [JsonPropertyName("destinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } = DefinitionHashPointer<DestinyDestinationDefinition>.Empty;


        public bool DeepEquals(DestinyMilestoneQuestDefinition other)
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
