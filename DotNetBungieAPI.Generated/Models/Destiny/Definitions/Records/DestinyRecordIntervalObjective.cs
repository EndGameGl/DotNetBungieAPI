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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordIntervalObjective? other)
    {
        if (other is null) return;
        if (IntervalObjectiveHash != other.IntervalObjectiveHash)
        {
            IntervalObjectiveHash = other.IntervalObjectiveHash;
            OnPropertyChanged(nameof(IntervalObjectiveHash));
        }
        if (IntervalScoreValue != other.IntervalScoreValue)
        {
            IntervalScoreValue = other.IntervalScoreValue;
            OnPropertyChanged(nameof(IntervalScoreValue));
        }
    }
}