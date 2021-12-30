using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Activities;

public sealed class DestinyPublicActivityStatus
{

    [JsonPropertyName("challengeObjectiveHashes")]
    public List<uint> ChallengeObjectiveHashes { get; init; }

    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; init; }

    [JsonPropertyName("rewardTooltipItems")]
    public List<Destiny.DestinyItemQuantity> RewardTooltipItems { get; init; }
}
