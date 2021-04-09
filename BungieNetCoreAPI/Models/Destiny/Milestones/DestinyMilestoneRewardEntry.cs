using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneRewardEntry
    {
        [JsonPropertyName("rewardEntryHash")]
        public uint RewardEntryHash { get; init; }
        [JsonPropertyName("earned")]
        public bool Earned { get; init; }
        [JsonPropertyName("redeemed")]
        public bool Redeemed { get; init; }
    }
}
