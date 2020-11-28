using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordIntervalInfo
    {
        public List<object> IntervalObjectives { get; }
        public bool IsIntervalVersionedFromNormalRecord { get; }
        public int OriginalObjectiveArrayInsertionIndex { get; }

        [JsonConstructor]
        private RecordIntervalInfo(List<object> intervalObjectives, bool isIntervalVersionedFromNormalRecord, int originalObjectiveArrayInsertionIndex)
        {
            IntervalObjectives = intervalObjectives;
            IsIntervalVersionedFromNormalRecord = isIntervalVersionedFromNormalRecord;
            OriginalObjectiveArrayInsertionIndex = originalObjectiveArrayInsertionIndex;
        }
    }
}
