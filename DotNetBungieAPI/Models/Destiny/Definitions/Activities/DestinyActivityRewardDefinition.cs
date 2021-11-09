namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities
{
    /// <summary>
    ///     Activities can refer to one or more sets of tooltip-friendly reward data. These are the definitions for those
    ///     tooltip friendly rewards.
    /// </summary>
    public sealed record DestinyActivityRewardDefinition : IDeepEquatable<DestinyActivityRewardDefinition>
    {
        /// <summary>
        ///     The header for the reward set, if any.
        /// </summary>
        [JsonPropertyName("rewardText")]
        public string RewardText { get; init; }

        /// <summary>
        ///     The "Items provided" in the reward. This is almost always a pointer to a DestinyInventoryItemDefintion for an item
        ///     that you can't actually earn in-game, but that has name/description/icon information for the vague concept of the
        ///     rewards you will receive. This is because the actual reward generation is non-deterministic and extremely
        ///     complicated, so the best the game can do is tell you what you'll get in vague terms. And so too shall we.
        ///     <para />
        ///     Interesting trivia: you actually *do* earn these items when you complete the activity. They go into a single-slot
        ///     bucket on your profile, which is how you see the pop-ups of these rewards when you complete an activity that match
        ///     these "dummy" items. You can even see them if you look at the last one you earned in your profile-level inventory
        ///     through the BNet API! Who said reading documentation is a waste of time?
        /// </summary>
        [JsonPropertyName("rewardItems")]
        public ReadOnlyCollection<DestinyItemQuantity> RewardItems { get; init; } =
            ReadOnlyCollections<DestinyItemQuantity>.Empty;

        public bool DeepEquals(DestinyActivityRewardDefinition other)
        {
            return other != null &&
                   RewardText == other.RewardText &&
                   RewardItems.DeepEqualsReadOnlyCollections(other.RewardItems);
        }
    }
}