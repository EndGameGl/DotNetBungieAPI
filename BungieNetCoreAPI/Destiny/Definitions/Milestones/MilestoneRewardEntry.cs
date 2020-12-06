using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneRewardEntry
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<MilestoneItem> Items { get; }
        public int Order { get; }
        public uint RewardEntryHash { get; }
        public string RewardEntryIdentifier { get; }

        [JsonConstructor]
        private MilestoneRewardEntry(DestinyDefinitionDisplayProperties displayProperties, List<MilestoneItem> items, int order, uint rewardEntryHash, string rewardEntryIdentifier)
        {
            DisplayProperties = displayProperties;
            Items = items;
            Order = order;
            RewardEntryHash = rewardEntryHash;
            RewardEntryIdentifier = rewardEntryIdentifier;
        }
    }
}
