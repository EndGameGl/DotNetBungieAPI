namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyActivityRewardMapping
{
    [JsonPropertyName("displayBehavior")]
    public Destiny.DestinyActivityRewardDisplayMode DisplayBehavior { get; init; }

    [JsonPropertyName("rewardItems")]
    public Destiny.Definitions.DestinyActivityRewardItem[]? RewardItems { get; init; }
}
