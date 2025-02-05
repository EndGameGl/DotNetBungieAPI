﻿using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

/// <summary>
///     The definition of a category of rewards, that contains many individual rewards.
/// </summary>
public sealed record DestinyMilestoneRewardCategoryDefinition
    : IDeepEquatable<DestinyMilestoneRewardCategoryDefinition>
{
    /// <summary>
    ///     Identifies the reward category. Only guaranteed unique within this specific component!
    /// </summary>
    [JsonPropertyName("categoryHash")]
    public uint CategoryHash { get; init; }

    /// <summary>
    ///     The string identifier for the category, if you want to use it for some end. Guaranteed unique within the specific
    ///     component.
    /// </summary>
    [JsonPropertyName("categoryIdentifier")]
    public string CategoryIdentifier { get; init; }

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     If this milestone can provide rewards, this will define the sets of rewards that can be earned, the conditions
    ///     under which they can be acquired, internal data that we'll use at runtime to determine whether you've already
    ///     earned or redeemed this set of rewards, and the category that this reward should be placed under.
    /// </summary>
    [JsonPropertyName("rewardEntries")]
    public ReadOnlyDictionary<
        uint,
        DestinyMilestoneRewardEntryDefinition
    > RewardEntries { get; init; } =
        ReadOnlyDictionary<uint, DestinyMilestoneRewardEntryDefinition>.Empty;

    /// <summary>
    ///     If you want to use BNet's recommended order for rendering categories programmatically, use this value and compare
    ///     it to other categories to determine the order in which they should be rendered. I don't feel great about putting
    ///     this here, I won't lie.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; init; }

    public bool DeepEquals(DestinyMilestoneRewardCategoryDefinition other)
    {
        return other != null
            && CategoryHash == other.CategoryHash
            && CategoryIdentifier == other.CategoryIdentifier
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Order == other.Order
            && RewardEntries.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(
                other.RewardEntries
            );
    }
}
