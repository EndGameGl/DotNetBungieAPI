using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordIntervalInfo
    {
        public List<RecordIntervalInfoObjective> IntervalObjectives { get; }
        public bool IsIntervalVersionedFromNormalRecord { get; }
        public int OriginalObjectiveArrayInsertionIndex { get; }

        [JsonConstructor]
        private RecordIntervalInfo(List<RecordIntervalInfoObjective> intervalObjectives, bool isIntervalVersionedFromNormalRecord, int originalObjectiveArrayInsertionIndex)
        {
            IntervalObjectives = intervalObjectives;
            IsIntervalVersionedFromNormalRecord = isIntervalVersionedFromNormalRecord;
            OriginalObjectiveArrayInsertionIndex = originalObjectiveArrayInsertionIndex;
        }
    }
}
