namespace DotNetBungieAPI.Models.Destiny.Definitions.Progressions;

public sealed record DestinyProgressionRewardItemQuantity
    : DestinyItemQuantity,
        IDeepEquatable<DestinyProgressionRewardItemQuantity>
{
    [JsonPropertyName("rewardItemIndex")]
    public int RewardItemIndex { get; init; }

    [JsonPropertyName("acquisitionBehavior")]
    public DestinyProgressionRewardItemAcquisitionBehavior AcquisitionBehavior { get; init; }

    [JsonPropertyName("claimUnlockDisplayStrings")]
    public ReadOnlyCollection<string> ClaimUnlockDisplayStrings { get; init; } =
        ReadOnlyCollection<string>.Empty;

    [JsonPropertyName("rewardedAtProgressionLevel")]
    public int RewardedAtProgressionLevel { get; init; }

    [JsonPropertyName("uiDisplayStyle")]
    public string UiDisplayStyle { get; init; }

    [JsonPropertyName("socketOverrides")]
    public ReadOnlyCollection<DestinyProgressionSocketPlugOverride> SocketOverrides { get; init; } =
        ReadOnlyCollection<DestinyProgressionSocketPlugOverride>.Empty;

    public bool DeepEquals(DestinyProgressionRewardItemQuantity other)
    {
        return other != null
            && AcquisitionBehavior == other.AcquisitionBehavior
            && ClaimUnlockDisplayStrings.DeepEqualsReadOnlySimpleCollection(
                other.ClaimUnlockDisplayStrings
            )
            && Item.DeepEquals(other.Item)
            && Quantity == other.Quantity
            && RewardedAtProgressionLevel == other.RewardedAtProgressionLevel
            && UiDisplayStyle == other.UiDisplayStyle
            && ItemInstanceId == other.ItemInstanceId;
    }
}
