using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordIntervalInfo : IDeepEquatable<RecordIntervalInfo>
    {
        public ReadOnlyCollection<RecordIntervalInfoObjective> IntervalObjectives { get; }
        public ReadOnlyCollection<RecordIntervalRewards> IntervalRewards { get; }
        public bool IsIntervalVersionedFromNormalRecord { get; }
        public int OriginalObjectiveArrayInsertionIndex { get; }

        [JsonConstructor]
        internal RecordIntervalInfo(RecordIntervalInfoObjective[] intervalObjectives, bool isIntervalVersionedFromNormalRecord, 
            int originalObjectiveArrayInsertionIndex, RecordIntervalRewards[] intervalRewards)
        {
            IntervalObjectives = intervalObjectives.AsReadOnlyOrEmpty();
            IsIntervalVersionedFromNormalRecord = isIntervalVersionedFromNormalRecord;
            OriginalObjectiveArrayInsertionIndex = originalObjectiveArrayInsertionIndex;
            IntervalRewards = intervalRewards.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(RecordIntervalInfo other)
        {
            return other != null &&
                   IntervalObjectives.DeepEqualsReadOnlyCollections(other.IntervalObjectives) &&
                   IntervalRewards.DeepEqualsReadOnlyCollections(other.IntervalRewards) &&
                   IsIntervalVersionedFromNormalRecord == other.IsIntervalVersionedFromNormalRecord &&
                   OriginalObjectiveArrayInsertionIndex == other.OriginalObjectiveArrayInsertionIndex;
        }
    }
}
