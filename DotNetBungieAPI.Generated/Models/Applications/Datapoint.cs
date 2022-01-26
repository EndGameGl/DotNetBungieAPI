namespace DotNetBungieAPI.Generated.Models.Applications;

public class Datapoint : IDeepEquatable<Datapoint>
{
    /// <summary>
    ///     Timestamp for the related count.
    /// </summary>
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }

    /// <summary>
    ///     Count associated with timestamp
    /// </summary>
    [JsonPropertyName("count")]
    public double? Count { get; set; }

    public bool DeepEquals(Datapoint? other)
    {
        return other is not null &&
               Time == other.Time &&
               Count == other.Count;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(Datapoint? other)
    {
        if (other is null) return;
        if (Time != other.Time)
        {
            Time = other.Time;
            OnPropertyChanged(nameof(Time));
        }
        if (Count != other.Count)
        {
            Count = other.Count;
            OnPropertyChanged(nameof(Count));
        }
    }
}