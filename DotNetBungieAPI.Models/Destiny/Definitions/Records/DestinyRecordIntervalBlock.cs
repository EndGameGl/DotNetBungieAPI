namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed record DestinyRecordIntervalBlock : IDeepEquatable<DestinyRecordIntervalBlock>
{
    [JsonPropertyName("intervalObjectives")]
    public ReadOnlyCollection<DestinyRecordIntervalObjective> IntervalObjectives { get; init; } =
        ReadOnlyCollection<DestinyRecordIntervalObjective>.Empty;

    [JsonPropertyName("intervalRewards")]
    public ReadOnlyCollection<DestinyRecordIntervalRewards> IntervalRewards { get; init; } =
        ReadOnlyCollection<DestinyRecordIntervalRewards>.Empty;

    [JsonPropertyName("isIntervalVersionedFromNormalRecord")]
    public bool IsIntervalVersionedFromNormalRecord { get; init; }

    [JsonPropertyName("originalObjectiveArrayInsertionIndex")]
    public int OriginalObjectiveArrayInsertionIndex { get; init; }

    public bool DeepEquals(DestinyRecordIntervalBlock other)
    {
        return other != null
            && IntervalObjectives.DeepEqualsReadOnlyCollection(other.IntervalObjectives)
            && IntervalRewards.DeepEqualsReadOnlyCollection(other.IntervalRewards)
            && IsIntervalVersionedFromNormalRecord == other.IsIntervalVersionedFromNormalRecord
            && OriginalObjectiveArrayInsertionIndex == other.OriginalObjectiveArrayInsertionIndex;
    }
}
