using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneRewardCategory
    {
        public uint RewardCategoryHash { get; init; }
        public ReadOnlyCollection<DestinyMilestoneReward> Entries { get; init; }

        [JsonConstructor]
        internal DestinyMilestoneRewardCategory(uint rewardCategoryHash, DestinyMilestoneReward[] entries)
        {
            RewardCategoryHash = rewardCategoryHash;
            Entries = entries.AsReadOnlyOrEmpty();
        }
    }
}
