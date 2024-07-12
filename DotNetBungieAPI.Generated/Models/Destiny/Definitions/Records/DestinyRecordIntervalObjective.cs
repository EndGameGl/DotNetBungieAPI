namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalObjective
{
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("intervalObjectiveHash")]
    public uint? IntervalObjectiveHash { get; set; }

    [JsonPropertyName("intervalScoreValue")]
    public int? IntervalScoreValue { get; set; }
}
