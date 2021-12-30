using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityRewardDefinition
{

    [JsonPropertyName("rewardText")]
    public string RewardText { get; init; }

    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; init; }
}
