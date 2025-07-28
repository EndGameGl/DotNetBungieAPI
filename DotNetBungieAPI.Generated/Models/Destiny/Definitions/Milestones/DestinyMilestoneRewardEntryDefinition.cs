namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     The definition of a specific reward, which may be contained in a category of rewards and that has optional information about how it is obtained.
/// </summary>
public class DestinyMilestoneRewardEntryDefinition
{
    /// <summary>
    ///     The identifier for this reward entry. Runtime data will refer to reward entries by this hash. Only guaranteed unique within the specific Milestone.
    /// </summary>
    [JsonPropertyName("rewardEntryHash")]
    public uint RewardEntryHash { get; set; }

    /// <summary>
    ///     The string identifier, if you care about it. Only guaranteed unique within the specific Milestone.
    /// </summary>
    [JsonPropertyName("rewardEntryIdentifier")]
    public string RewardEntryIdentifier { get; set; }

    /// <summary>
    ///     The items you will get as rewards, and how much of it you'll get.
    /// </summary>
    [JsonPropertyName("items")]
    public Destiny.DestinyItemQuantity[]? Items { get; set; }

    /// <summary>
    ///     If this reward is redeemed at a Vendor, this is the hash of the Vendor to go to in order to redeem the reward. Use this hash to look up the DestinyVendorDefinition.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyVendorDefinition>("Destiny.Definitions.DestinyVendorDefinition")]
    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; set; }

    /// <summary>
    ///     For us to bother returning this info, we should be able to return some kind of information about why these rewards are grouped together. This is ideally that information. Look at how confident I am that this will always remain true.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     If you want to follow BNet's ordering of these rewards, use this number within a given category to order the rewards. Yeah, I know. I feel dirty too.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }
}
