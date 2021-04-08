using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordIntervalInfo : IDeepEquatable<RecordIntervalInfo>
    {
        public ReadOnlyCollection<RecordIntervalInfoObjective> IntervalObjectives { get; init; }
        public ReadOnlyCollection<RecordIntervalRewards> IntervalRewards { get; init; }
        public bool IsIntervalVersionedFromNormalRecord { get; init; }
        public int OriginalObjectiveArrayInsertionIndex { get; init; }

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
