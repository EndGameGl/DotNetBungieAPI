using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// Represents a reference to a Challenge, which for now is just an Objective.
    /// </summary>
    public class ActivityChallengeEntry : IDeepEquatable<ActivityChallengeEntry>
    {
        /// <summary>
        /// The rewards as they're represented in the UI. Note that they generally link to "dummy" items that give a summary of rewards rather than direct, real items themselves.
        /// <para />
        /// If the quantity is 0, don't show the quantity.
        /// </summary>
        public ReadOnlyCollection<ActivityItemRewardEntry> DummyRewards { get; }
        public int InhibitRewardsUnlockHash { get; }
        /// <summary>
        /// Objective that matches this challenge
        /// </summary>
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public uint RewardSiteHash { get; }

        [JsonConstructor]
        internal ActivityChallengeEntry(ActivityItemRewardEntry[] dummyRewards, int inhibitRewardsUnlockHash, uint objectiveHash, uint rewardSiteHash)
        {
            DummyRewards = dummyRewards.AsReadOnlyOrEmpty();
            InhibitRewardsUnlockHash = inhibitRewardsUnlockHash;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            RewardSiteHash = rewardSiteHash;
        }

        public bool DeepEquals(ActivityChallengeEntry other)
        {
            return other != null &&
                   DummyRewards.DeepEqualsReadOnlyCollections(other.DummyRewards) &&
                   InhibitRewardsUnlockHash == other.InhibitRewardsUnlockHash &&
                   Objective.DeepEquals(other.Objective) &&
                   RewardSiteHash == other.RewardSiteHash;
        }
    }
}
