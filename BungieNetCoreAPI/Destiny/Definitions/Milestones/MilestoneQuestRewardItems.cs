using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    /// <summary>
    /// If rewards are given in a quest - as opposed to overall in the entire Milestone - there's way less to track. We're going to simplify this contract as a result. However, this also gives us the opportunity to potentially put more than just item information into the reward data if we're able to mine it out in the future. Remember this if you come back and ask "why are quest reward items nested inside of their own class?"
    /// </summary>
    public class MilestoneQuestRewardItems : IDeepEquatable<MilestoneQuestRewardItems>
    {
        public ReadOnlyCollection<MilestoneItem> Items { get; }

        [JsonConstructor]
        internal MilestoneQuestRewardItems(MilestoneItem[] items)
        {
            Items = items.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(MilestoneQuestRewardItems other)
        {
            return other != null && Items.DeepEqualsReadOnlyCollections(other.Items);
        }
    }
}
