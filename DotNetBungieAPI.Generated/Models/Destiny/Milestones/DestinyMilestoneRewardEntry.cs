using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneRewardEntry
{

    [JsonPropertyName("rewardEntryHash")]
    public uint RewardEntryHash { get; init; }

    [JsonPropertyName("earned")]
    public bool Earned { get; init; }

    [JsonPropertyName("redeemed")]
    public bool Redeemed { get; init; }
}
