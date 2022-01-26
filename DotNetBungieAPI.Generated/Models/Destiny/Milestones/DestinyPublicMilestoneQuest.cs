namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public class DestinyPublicMilestoneQuest : IDeepEquatable<DestinyPublicMilestoneQuest>
{
    /// <summary>
    ///     Quests are defined as Items in content. As such, this is the hash identifier of the DestinyInventoryItemDefinition that represents this quest. It will have pointers to all of the steps in the quest, and display information for the quest (title, description, icon etc) Individual steps will be referred to in the Quest item's DestinyInventoryItemDefinition.setData property, and themselves are Items with their own renderable data.
    /// </summary>
    [JsonPropertyName("questItemHash")]
    public uint QuestItemHash { get; set; }

    /// <summary>
    ///     A milestone need not have an active activity, but if there is one it will be returned here, along with any variant and additional information.
    /// </summary>
    [JsonPropertyName("activity")]
    public Destiny.Milestones.DestinyPublicMilestoneActivity Activity { get; set; }

    /// <summary>
    ///     For the given quest there could be 0-to-Many challenges: mini quests that you can perform in the course of doing this quest, that may grant you rewards and benefits.
    /// </summary>
    [JsonPropertyName("challenges")]
    public List<Destiny.Milestones.DestinyPublicMilestoneChallenge> Challenges { get; set; }

    public bool DeepEquals(DestinyPublicMilestoneQuest? other)
    {
        return other is not null &&
               QuestItemHash == other.QuestItemHash &&
               (Activity is not null ? Activity.DeepEquals(other.Activity) : other.Activity is null) &&
               Challenges.DeepEqualsList(other.Challenges);
    }
}