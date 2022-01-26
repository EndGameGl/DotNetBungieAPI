namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalObjective : IDeepEquatable<DestinyRecordIntervalObjective>
{
    [JsonPropertyName("intervalObjectiveHash")]
    public uint IntervalObjectiveHash { get; set; }

    [JsonPropertyName("intervalScoreValue")]
    public int IntervalScoreValue { get; set; }

    public bool DeepEquals(DestinyRecordIntervalObjective? other)
    {
        return other is not null &&
               IntervalObjectiveHash == other.IntervalObjectiveHash &&
               IntervalScoreValue == other.IntervalScoreValue;
    }
}