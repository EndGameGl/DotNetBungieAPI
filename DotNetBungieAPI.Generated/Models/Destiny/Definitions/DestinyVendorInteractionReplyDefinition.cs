namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     When the interaction is replied to, Reward sites will fire and items potentially selected based on whether the given unlock expression is TRUE.
/// <para />
///     You can potentially choose one from multiple replies when replying to an interaction: this is how you get either/or rewards from vendors.
/// </summary>
public sealed class DestinyVendorInteractionReplyDefinition
{

    /// <summary>
    ///     The rewards granted upon responding to the vendor.
    /// </summary>
    [JsonPropertyName("itemRewardsSelection")]
    public Destiny.DestinyVendorInteractionRewardSelection ItemRewardsSelection { get; init; }

    /// <summary>
    ///     The localized text for the reply.
    /// </summary>
    [JsonPropertyName("reply")]
    public string Reply { get; init; }

    /// <summary>
    ///     An enum indicating the type of reply being made.
    /// </summary>
    [JsonPropertyName("replyType")]
    public Destiny.DestinyVendorReplyType ReplyType { get; init; }
}
