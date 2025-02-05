﻿using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

public sealed record DestinyMilestoneRewardEntryDefinition
    : IDeepEquatable<DestinyMilestoneRewardEntryDefinition>
{
    /// <summary>
    ///     The identifier for this reward entry. Runtime data will refer to reward entries by this hash. Only guaranteed
    ///     unique within the specific Milestone.
    /// </summary>
    [JsonPropertyName("rewardEntryHash")]
    public uint RewardEntryHash { get; init; }

    /// <summary>
    ///     The string identifier, if you care about it. Only guaranteed unique within the specific Milestone.
    /// </summary>
    [JsonPropertyName("rewardEntryIdentifier")]
    public string RewardEntryIdentifier { get; init; }

    /// <summary>
    ///     The items you will get as rewards, and how much of it you'll get.
    /// </summary>
    [JsonPropertyName("items")]
    public ReadOnlyCollection<DestinyItemQuantity> Items { get; init; } =
        ReadOnlyCollection<DestinyItemQuantity>.Empty;

    /// <summary>
    ///     If this reward is redeemed at a Vendor, this is the hash of the Vendor to go to in order to redeem the reward. Use
    ///     this hash to look up the DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    /// <summary>
    ///     For us to bother returning this info, we should be able to return some kind of information about why these rewards
    ///     are grouped together. This is ideally that information. Look at how confident I am that this will always remain
    ///     true.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     If you want to follow BNet's ordering of these rewards, use this number within a given category to order the
    ///     rewards.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }

    public bool DeepEquals(DestinyMilestoneRewardEntryDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Items.DeepEqualsReadOnlyCollection(other.Items)
            && Order == other.Order
            && RewardEntryHash == other.RewardEntryHash
            && RewardEntryIdentifier == other.RewardEntryIdentifier
            && Vendor.DeepEquals(other.Vendor);
    }
}
