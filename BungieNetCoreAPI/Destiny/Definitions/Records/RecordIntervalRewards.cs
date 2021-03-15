using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordIntervalRewards : IDeepEquatable<RecordIntervalRewards>
    {
        public ReadOnlyCollection<DestinyItemQuantity> IntervalRewardItems { get; }
        [JsonConstructor]
        internal RecordIntervalRewards(DestinyItemQuantity[] intervalRewardItems)
        {
            IntervalRewardItems = intervalRewardItems.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(RecordIntervalRewards other)
        {
            return other != null &&
                   IntervalRewardItems.DeepEqualsReadOnlyCollections(other.IntervalRewardItems);
        }
    }
}
