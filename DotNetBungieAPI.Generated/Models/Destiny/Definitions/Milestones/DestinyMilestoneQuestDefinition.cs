namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     Any data we need to figure out whether this Quest Item is the currently active one for the conceptual Milestone. Even just typing this description, I already regret it.
/// </summary>
public class DestinyMilestoneQuestDefinition : IDeepEquatable<DestinyMilestoneQuestDefinition>
{
    /// <summary>
    ///     The item representing this Milestone quest. Use this hash to look up the DestinyInventoryItemDefinition for the quest to find its steps and human readable data.
    /// </summary>
    [JsonPropertyName("questItemHash")]
    public uint QuestItemHash { get; set; }

    /// <summary>
    ///     The individual quests may have different definitions from the overall milestone: if there's a specific active quest, use these displayProperties instead of that of the overall DestinyMilestoneDefinition.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     If populated, this image can be shown instead of the generic milestone's image when this quest is live, or it can be used to show a background image for the quest itself that differs from that of the Activity or the Milestone.
    /// </summary>
    [JsonPropertyName("overrideImage")]
    public string OverrideImage { get; set; }

    /// <summary>
    ///     The rewards you will get for completing this quest, as best as we could extract them from our data. Sometimes, it'll be a decent amount of data. Sometimes, it's going to be sucky. Sorry.
    /// </summary>
    [JsonPropertyName("questRewards")]
    public Destiny.Definitions.Milestones.DestinyMilestoneQuestRewardsDefinition QuestRewards { get; set; }

    /// <summary>
    ///     The full set of all possible "conceptual activities" that are related to this Milestone. Tiers or alternative modes of play within these conceptual activities will be defined as sub-entities. Keyed by the Conceptual Activity Hash. Use the key to look up DestinyActivityDefinition.
    /// </summary>
    [JsonPropertyName("activities")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneActivityDefinition> Activities { get; set; }

    /// <summary>
    ///     Sometimes, a Milestone's quest is related to an entire Destination rather than a specific activity. In that situation, this will be the hash of that Destination. Hotspots are currently the only Milestones that expose this data, but that does not preclude this data from being returned for other Milestones in the future.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint? DestinationHash { get; set; }

    public bool DeepEquals(DestinyMilestoneQuestDefinition? other)
    {
        return other is not null &&
               QuestItemHash == other.QuestItemHash &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               OverrideImage == other.OverrideImage &&
               (QuestRewards is not null ? QuestRewards.DeepEquals(other.QuestRewards) : other.QuestRewards is null) &&
               Activities.DeepEqualsDictionary(other.Activities) &&
               DestinationHash == other.DestinationHash;
    }
}