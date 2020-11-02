using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityRewardEntry
    {
        public List<ActivityItemRewardEntry> RewardItems { get; }

        [JsonConstructor]
        private ActivityRewardEntry(List<ActivityItemRewardEntry> rewardItems)
        {
            if (rewardItems == null)
                RewardItems = new List<ActivityItemRewardEntry>();
            else
                RewardItems = rewardItems;
        }
    }
}
