using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyProgressionStepDefinition
{

    [JsonPropertyName("stepName")]
    public string StepName { get; init; }

    [JsonPropertyName("displayEffectType")]
    public Destiny.DestinyProgressionStepDisplayEffect DisplayEffectType { get; init; }

    [JsonPropertyName("progressTotal")]
    public int ProgressTotal { get; init; }

    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; init; }

    [JsonPropertyName("icon")]
    public string Icon { get; init; }
}
