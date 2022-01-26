namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Represents a stat on an item *or* Character (NOT a Historical Stat, but a physical attribute stat like Attack, Defense etc...)
/// </summary>
public class DestinyStat : IDeepEquatable<DestinyStat>
{
    /// <summary>
    ///     The hash identifier for the Stat. Use it to look up the DestinyStatDefinition for static data about the stat.
    /// </summary>
    [JsonPropertyName("statHash")]
    public uint StatHash { get; set; }

    /// <summary>
    ///     The current value of the Stat.
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }

    public bool DeepEquals(DestinyStat? other)
    {
        return other is not null &&
               StatHash == other.StatHash &&
               Value == other.Value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyStat? other)
    {
        if (other is null) return;
        if (StatHash != other.StatHash)
        {
            StatHash = other.StatHash;
            OnPropertyChanged(nameof(StatHash));
        }
        if (Value != other.Value)
        {
            Value = other.Value;
            OnPropertyChanged(nameof(Value));
        }
    }
}