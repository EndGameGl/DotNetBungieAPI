using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    /// <summary>
    /// The definition of a category of rewards, that contains many individual rewards.
    /// </summary>
    public class MilestoneReward : IDeepEquatable<MilestoneReward>
    {
        /// <summary>
        /// Identifies the reward category. Only guaranteed unique within this specific component!
        /// </summary>
        public uint CategoryHash { get; init; }
        /// <summary>
        /// The string identifier for the category, if you want to use it for some end. Guaranteed unique within the specific component.
        /// </summary>
        public string CategoryIdentifier { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// If you want to use BNet's recommended order for rendering categories programmatically, use this value and compare it to other categories to determine the order in which they should be rendered. I don't feel great about putting this here, I won't lie.
        /// </summary>
        public int Order { get; init; }
        /// <summary>
        /// If this milestone can provide rewards, this will define the sets of rewards that can be earned, the conditions under which they can be acquired, internal data that we'll use at runtime to determine whether you've already earned or redeemed this set of rewards, and the category that this reward should be placed under.
        /// </summary>
        public ReadOnlyDictionary<uint, MilestoneRewardEntry> RewardEntries { get; init; }

        [JsonConstructor]
        internal MilestoneReward(uint categoryHash, string categoryIdentifier, DestinyDisplayPropertiesDefinition displayProperties, int order, 
            Dictionary<uint, MilestoneRewardEntry> rewardEntries)
        {
            CategoryHash = categoryHash;
            CategoryIdentifier = categoryIdentifier;
            DisplayProperties = displayProperties;
            Order = order;
            RewardEntries = rewardEntries.AsReadOnlyDictionaryOrEmpty();
        }

        public bool DeepEquals(MilestoneReward other)
        {
            return other != null &&
                   CategoryHash == other.CategoryHash &&
                   CategoryIdentifier == other.CategoryIdentifier &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Order == other.Order &&
                   RewardEntries.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.RewardEntries);
        }
    }
}
