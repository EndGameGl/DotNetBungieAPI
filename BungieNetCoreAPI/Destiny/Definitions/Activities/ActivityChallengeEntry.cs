using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityChallengeEntry
    {
        public List<ActivityItemRewardEntry> DummyRewards { get; }
        public int InhibitRewardsUnlockHash { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public uint RewardSiteHash { get; }

        [JsonConstructor]
        private ActivityChallengeEntry(List<ActivityItemRewardEntry> dummyRewards, int inhibitRewardsUnlockHash, uint objectiveHash, uint rewardSiteHash)
        {
            if (dummyRewards == null)
                DummyRewards = new List<ActivityItemRewardEntry>();
            else
                DummyRewards = dummyRewards;
            InhibitRewardsUnlockHash = inhibitRewardsUnlockHash;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            RewardSiteHash = rewardSiteHash;
        }
    }
}
