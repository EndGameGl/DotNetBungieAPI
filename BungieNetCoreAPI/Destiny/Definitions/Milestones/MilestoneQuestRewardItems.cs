using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneQuestRewardItems
    {
        public List<MilestoneItem> Items { get; }

        [JsonConstructor]
        private MilestoneQuestRewardItems(List<MilestoneItem> items)
        {
            Items = items;
        }
    }
}
