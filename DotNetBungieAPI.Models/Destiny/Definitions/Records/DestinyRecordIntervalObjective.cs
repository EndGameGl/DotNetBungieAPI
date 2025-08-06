namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordIntervalObjective
{
    [JsonPropertyName("intervalObjectiveHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyObjectiveDefinition> IntervalObjectiveHash { get; init; }

    [JsonPropertyName("intervalScoreValue")]
    public int IntervalScoreValue { get; init; }
}
