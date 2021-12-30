using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneRewardCategory
{

    [JsonPropertyName("rewardCategoryHash")]
    public uint RewardCategoryHash { get; init; }

    [JsonPropertyName("entries")]
    public List<Destiny.Milestones.DestinyMilestoneRewardEntry> Entries { get; init; }
}
