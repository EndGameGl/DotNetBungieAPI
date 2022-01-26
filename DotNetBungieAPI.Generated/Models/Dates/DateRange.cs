namespace DotNetBungieAPI.Generated.Models.Dates;

public class DateRange : IDeepEquatable<DateRange>
{
    [JsonPropertyName("start")]
    public DateTime Start { get; set; }

    [JsonPropertyName("end")]
    public DateTime End { get; set; }

    public bool DeepEquals(DateRange? other)
    {
        return other is not null &&
               Start == other.Start &&
               End == other.End;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DateRange? other)
    {
        if (other is null) return;
        if (Start != other.Start)
        {
            Start = other.Start;
            OnPropertyChanged(nameof(Start));
        }
        if (End != other.End)
        {
            End = other.End;
            OnPropertyChanged(nameof(End));
        }
    }
}