using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalObjective : IDeepEquatable<DestinyRecordIntervalObjective>
{
    [JsonPropertyName("intervalObjectiveHash")]
    public DefinitionHashPointer<DestinyObjectiveDefinition> IntervalObjective { get; init; } =
        DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

    [JsonPropertyName("intervalScoreValue")]
    public int IntervalScoreValue { get; init; }

    public bool DeepEquals(DestinyRecordIntervalObjective other)
    {
        return other != null
            && IntervalObjective.DeepEquals(other.IntervalObjective)
            && IntervalScoreValue == other.IntervalScoreValue;
    }
}
