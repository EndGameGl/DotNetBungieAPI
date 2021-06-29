using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace NetBungieAPI.Models.Destiny.Definitions.Activities
{
    /// <summary>
    ///     Represents a reference to a Challenge, which for now is just an Objective.
    /// </summary>
    public sealed record DestinyActivityChallengeDefinition : IDeepEquatable<DestinyActivityChallengeDefinition>
    {
        /// <summary>
        ///     The rewards as they're represented in the UI. Note that they generally link to "dummy" items that give a summary of
        ///     rewards rather than direct, real items themselves.
        ///     <para />
        ///     If the quantity is 0, don't show the quantity.
        /// </summary>
        [JsonPropertyName("dummyRewards")]
        public ReadOnlyCollection<DestinyItemQuantity> DummyRewards { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();

        [JsonPropertyName("inhibitRewardsUnlockHash")]
        public int InhibitRewardsUnlockHash { get; init; }

        /// <summary>
        ///     Objective that matches this challenge
        /// </summary>
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } =
            DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

        [JsonPropertyName("rewardSiteHash")] public uint RewardSiteHash { get; init; }

        public bool DeepEquals(DestinyActivityChallengeDefinition other)
        {
            return other != null &&
                   DummyRewards.DeepEqualsReadOnlyCollections(other.DummyRewards) &&
                   InhibitRewardsUnlockHash == other.InhibitRewardsUnlockHash &&
                   Objective.DeepEquals(other.Objective) &&
                   RewardSiteHash == other.RewardSiteHash;
        }
    }
}