namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     If rewards are given in a quest - as opposed to overall in the entire Milestone - there's way less to track. We're going to simplify this contract as a result. However, this also gives us the opportunity to potentially put more than just item information into the reward data if we're able to mine it out in the future. Remember this if you come back and ask "why are quest reward items nested inside of their own class?"
/// </summary>
public class DestinyMilestoneQuestRewardsDefinition : IDeepEquatable<DestinyMilestoneQuestRewardsDefinition>
{
    /// <summary>
    ///     The items that represent your reward for completing the quest.
    /// <para />
    ///     Be warned, these could be "dummy" items: items that are only used to render a good-looking in-game tooltip, but aren't the actual items themselves.
    /// <para />
    ///     For instance, when experience is given there's often a dummy item representing "experience", with quantity being the amount of experience you got. We don't have a programmatic association between those and whatever Progression is actually getting that experience... yet.
    /// </summary>
    [JsonPropertyName("items")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneQuestRewardItem> Items { get; set; }

    public bool DeepEquals(DestinyMilestoneQuestRewardsDefinition? other)
    {
        return other is not null &&
               Items.DeepEqualsList(other.Items);
    }
}