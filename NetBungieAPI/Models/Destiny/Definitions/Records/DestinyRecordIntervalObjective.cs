using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace NetBungieAPI.Models.Destiny.Definitions.Records
{
    public class DestinyRecordIntervalObjective : IDeepEquatable<DestinyRecordIntervalObjective>
    {
        [JsonPropertyName("intervalObjectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> IntervalObjective { get; init; } =
            DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

        [JsonPropertyName("intervalScoreValue")]
        public int IntervalScoreValue { get; init; }

        public bool DeepEquals(DestinyRecordIntervalObjective other)
        {
            return other != null &&
                   IntervalObjective.DeepEquals(other.IntervalObjective) &&
                   IntervalScoreValue == other.IntervalScoreValue;
        }
    }
}