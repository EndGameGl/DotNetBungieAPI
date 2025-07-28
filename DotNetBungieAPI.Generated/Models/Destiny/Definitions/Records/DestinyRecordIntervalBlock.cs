namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalBlock
{
    [JsonPropertyName("intervalObjectives")]
    public Destiny.Definitions.Records.DestinyRecordIntervalObjective[]? IntervalObjectives { get; set; }

    [JsonPropertyName("intervalRewards")]
    public Destiny.Definitions.Records.DestinyRecordIntervalRewards[]? IntervalRewards { get; set; }

    [JsonPropertyName("originalObjectiveArrayInsertionIndex")]
    public int OriginalObjectiveArrayInsertionIndex { get; set; }
}
