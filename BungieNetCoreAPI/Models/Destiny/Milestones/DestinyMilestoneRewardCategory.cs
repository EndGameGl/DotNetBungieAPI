using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneRewardCategory
    {
        [JsonPropertyName("rewardCategoryHash")]
        public uint RewardCategoryHash { get; init; }
        [JsonPropertyName("entries")]
        public ReadOnlyCollection<DestinyMilestoneRewardEntry> Entries { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneRewardEntry>();
    }
}
