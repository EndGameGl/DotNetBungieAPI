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

    /// <summary>
    ///     The hash identifier for the item in question. Use it to look up the item's DestinyInventoryItemDefinition.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    /// <summary>
    ///     If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally, this will be null.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    /// <summary>
    ///     The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    ///     Indicates that this item quantity may be conditionally shown or hidden, based on various sources of state. For example: server flags, account state, or character progress.
    /// </summary>
    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; init; }
}
