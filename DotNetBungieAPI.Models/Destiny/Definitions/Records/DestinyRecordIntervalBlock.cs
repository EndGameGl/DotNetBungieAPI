namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordIntervalBlock
{
    [JsonPropertyName("intervalObjectives")]
    public Destiny.Definitions.Records.DestinyRecordIntervalObjective[]? IntervalObjectives { get; init; }

    [JsonPropertyName("intervalRewards")]
    public Destiny.Definitions.Records.DestinyRecordIntervalRewards[]? IntervalRewards { get; init; }

    [JsonPropertyName("originalObjectiveArrayInsertionIndex")]
    public int OriginalObjectiveArrayInsertionIndex { get; init; }
}
