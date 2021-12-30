using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Represents a category of "summary" rewards that can be earned for the Milestone regardless of specific quest rewards that can be earned.
/// </summary>
public sealed class DestinyMilestoneRewardCategory
{

    /// <summary>
    ///     Look up the relevant DestinyMilestoneDefinition, and then use rewardCategoryHash to look up the category info in DestinyMilestoneDefinition.rewards.
    /// </summary>
    [JsonPropertyName("rewardCategoryHash")]
    public uint RewardCategoryHash { get; init; }

    /// <summary>
    ///     The individual reward entries for this category, and their status.
    /// </summary>
    [JsonPropertyName("entries")]
    public List<Destiny.Milestones.DestinyMilestoneRewardEntry> Entries { get; init; }
}
