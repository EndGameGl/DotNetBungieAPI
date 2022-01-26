namespace DotNetBungieAPI.Generated.Models.Destiny.Misc;

/// <summary>
///     Represents a color whose RGBA values are all represented as values between 0 and 255.
/// </summary>
public class DestinyColor : IDeepEquatable<DestinyColor>
{
    [JsonPropertyName("red")]
    public string Red { get; set; }

    [JsonPropertyName("green")]
    public string Green { get; set; }

    [JsonPropertyName("blue")]
    public string Blue { get; set; }

    [JsonPropertyName("alpha")]
    public string Alpha { get; set; }

    public bool DeepEquals(DestinyColor? other)
    {
        return other is not null &&
               Red == other.Red &&
               Green == other.Green &&
               Blue == other.Blue &&
               Alpha == other.Alpha;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyColor? other)
    {
        if (other is null) return;
        if (Red != other.Red)
        {
            Red = other.Red;
            OnPropertyChanged(nameof(Red));
        }
        if (Green != other.Green)
        {
            Green = other.Green;
            OnPropertyChanged(nameof(Green));
        }
        if (Blue != other.Blue)
        {
            Blue = other.Blue;
            OnPropertyChanged(nameof(Blue));
        }
        if (Alpha != other.Alpha)
        {
            Alpha = other.Alpha;
            OnPropertyChanged(nameof(Alpha));
        }
    }
}