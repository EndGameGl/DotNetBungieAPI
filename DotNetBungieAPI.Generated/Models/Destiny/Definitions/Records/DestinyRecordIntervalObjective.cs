using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordIntervalObjective
{

    [JsonPropertyName("intervalObjectiveHash")]
    public uint IntervalObjectiveHash { get; init; } // DestinyObjectiveDefinition

    [JsonPropertyName("intervalScoreValue")]
    public int IntervalScoreValue { get; init; }
}
