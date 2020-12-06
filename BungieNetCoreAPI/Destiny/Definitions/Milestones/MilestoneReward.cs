using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneReward
    {
        public uint CategoryHash { get; }
        public string CategoryIdentifier { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int Order { get; }
        public Dictionary<uint, MilestoneRewardEntry> RewardEntries { get; }

        [JsonConstructor]
        private MilestoneReward(uint categoryHash, string categoryIdentifier, DestinyDefinitionDisplayProperties displayProperties, int order, 
            Dictionary<uint, MilestoneRewardEntry> rewardEntries)
        {
            CategoryHash = categoryHash;
            CategoryIdentifier = categoryIdentifier;
            DisplayProperties = displayProperties;
            Order = order;
            RewardEntries = rewardEntries;
        }
    }
}
