namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordIntervalBlock
{

    [JsonPropertyName("intervalObjectives")]
    public List<Destiny.Definitions.Records.DestinyRecordIntervalObjective> IntervalObjectives { get; init; }

    [JsonPropertyName("intervalRewards")]
    public List<Destiny.Definitions.Records.DestinyRecordIntervalRewards> IntervalRewards { get; init; }

    [JsonPropertyName("originalObjectiveArrayInsertionIndex")]
    public int OriginalObjectiveArrayInsertionIndex { get; init; }
}
