using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyProgressionRewardItemQuantity
{

    [JsonPropertyName("rewardedAtProgressionLevel")]
    public int RewardedAtProgressionLevel { get; init; }

    [JsonPropertyName("acquisitionBehavior")]
    public Destiny.DestinyProgressionRewardItemAcquisitionBehavior AcquisitionBehavior { get; init; }

    [JsonPropertyName("uiDisplayStyle")]
    public string UiDisplayStyle { get; init; }

    [JsonPropertyName("claimUnlockDisplayStrings")]
    public List<string> ClaimUnlockDisplayStrings { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; init; }
}
