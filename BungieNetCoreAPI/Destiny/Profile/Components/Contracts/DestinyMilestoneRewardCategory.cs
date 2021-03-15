using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneRewardCategory
    {
        public uint RewardCategoryHash { get; }
        public ReadOnlyCollection<DestinyMilestoneReward> Entries { get; }

        [JsonConstructor]
        internal DestinyMilestoneRewardCategory(uint rewardCategoryHash, DestinyMilestoneReward[] entries)
        {
            RewardCategoryHash = rewardCategoryHash;
            Entries = entries.AsReadOnlyOrEmpty();
        }
    }
}
