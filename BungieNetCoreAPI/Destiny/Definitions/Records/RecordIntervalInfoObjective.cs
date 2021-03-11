using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordIntervalInfoObjective : IDeepEquatable<RecordIntervalInfoObjective>
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> IntervalObjective { get; }
        public int IntervalScoreValue { get; }

        [JsonConstructor]
        internal RecordIntervalInfoObjective(uint intervalObjectiveHash, int intervalScoreValue)
        {
            IntervalObjective = new DefinitionHashPointer<DestinyObjectiveDefinition>(intervalObjectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            IntervalScoreValue = intervalScoreValue;
        }

        public bool DeepEquals(RecordIntervalInfoObjective other)
        {
            return other != null &&
                   IntervalObjective.DeepEquals(other.IntervalObjective) &&
                   IntervalScoreValue == other.IntervalScoreValue;
        }
    }
}
