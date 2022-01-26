namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalBlock : IDeepEquatable<DestinyRecordIntervalBlock>
{
    [JsonPropertyName("intervalObjectives")]
    public List<Destiny.Definitions.Records.DestinyRecordIntervalObjective> IntervalObjectives { get; set; }

    [JsonPropertyName("intervalRewards")]
    public List<Destiny.Definitions.Records.DestinyRecordIntervalRewards> IntervalRewards { get; set; }

    [JsonPropertyName("originalObjectiveArrayInsertionIndex")]
    public int OriginalObjectiveArrayInsertionIndex { get; set; }

    public bool DeepEquals(DestinyRecordIntervalBlock? other)
    {
        return other is not null &&
               IntervalObjectives.DeepEqualsList(other.IntervalObjectives) &&
               IntervalRewards.DeepEqualsList(other.IntervalRewards) &&
               OriginalObjectiveArrayInsertionIndex == other.OriginalObjectiveArrayInsertionIndex;
    }
}