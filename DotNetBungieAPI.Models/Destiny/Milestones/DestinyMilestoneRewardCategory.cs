namespace DotNetBungieAPI.Models.Destiny.Milestones;

/// <summary>
///     Represents a category of "summary" rewards that can be earned for the Milestone regardless of specific quest
///     rewards that can be earned.
/// </summary>
public sealed record DestinyMilestoneRewardCategory
{
    /// <summary>
    ///     Look up the relevant DestinyMilestoneDefinition, and then use rewardCategoryHash to look up the category info in
    ///     DestinyMilestoneDefinition.rewards.
    /// </summary>
    [JsonPropertyName("rewardCategoryHash")]
    public uint RewardCategoryHash { get; init; }

    /// <summary>
    ///     The individual reward entries for this category, and their status.
    /// </summary>
    [JsonPropertyName("entries")]
    public ReadOnlyCollection<DestinyMilestoneRewardEntry> Entries { get; init; } =
        ReadOnlyCollections<DestinyMilestoneRewardEntry>.Empty;
}