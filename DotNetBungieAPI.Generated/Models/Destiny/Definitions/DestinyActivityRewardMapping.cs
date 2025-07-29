namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityRewardMapping
{
    [JsonPropertyName("displayBehavior")]
    public Destiny.DestinyActivityRewardDisplayMode DisplayBehavior { get; set; }

    [JsonPropertyName("rewardItems")]
    public Destiny.Definitions.DestinyActivityRewardItem[]? RewardItems { get; set; }
}
