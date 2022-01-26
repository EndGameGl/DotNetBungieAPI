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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordIntervalBlock? other)
    {
        if (other is null) return;
        if (!IntervalObjectives.DeepEqualsList(other.IntervalObjectives))
        {
            IntervalObjectives = other.IntervalObjectives;
            OnPropertyChanged(nameof(IntervalObjectives));
        }
        if (!IntervalRewards.DeepEqualsList(other.IntervalRewards))
        {
            IntervalRewards = other.IntervalRewards;
            OnPropertyChanged(nameof(IntervalRewards));
        }
        if (OriginalObjectiveArrayInsertionIndex != other.OriginalObjectiveArrayInsertionIndex)
        {
            OriginalObjectiveArrayInsertionIndex = other.OriginalObjectiveArrayInsertionIndex;
            OnPropertyChanged(nameof(OriginalObjectiveArrayInsertionIndex));
        }
    }
}