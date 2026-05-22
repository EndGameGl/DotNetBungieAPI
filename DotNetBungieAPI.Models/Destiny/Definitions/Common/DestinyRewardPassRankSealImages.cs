namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

public sealed class DestinyRewardPassRankSealImages
{
    [JsonPropertyName("rewardPassRankSealImagePath")]
    public string RewardPassRankSealImagePath { get; init; }

    [JsonPropertyName("rewardPassRankSealPremiumImagePath")]
    public string RewardPassRankSealPremiumImagePath { get; init; }

    [JsonPropertyName("rewardPassRankSealPrestigeImagePath")]
    public string RewardPassRankSealPrestigeImagePath { get; init; }

    [JsonPropertyName("rewardPassRankSealPremiumPrestigeImagePath")]
    public string RewardPassRankSealPremiumPrestigeImagePath { get; init; }
}
