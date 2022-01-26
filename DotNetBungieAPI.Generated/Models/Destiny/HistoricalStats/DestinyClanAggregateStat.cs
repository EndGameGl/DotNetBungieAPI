namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyClanAggregateStat : IDeepEquatable<DestinyClanAggregateStat>
{
    /// <summary>
    ///     The id of the mode of stats (allPvp, allPvE, etc)
    /// </summary>
    [JsonPropertyName("mode")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType Mode { get; set; }

    /// <summary>
    ///     The id of the stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    /// <summary>
    ///     Value of the stat for this player
    /// </summary>
    [JsonPropertyName("value")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Value { get; set; }

    public bool DeepEquals(DestinyClanAggregateStat? other)
    {
        return other is not null &&
               Mode == other.Mode &&
               StatId == other.StatId &&
               (Value is not null ? Value.DeepEquals(other.Value) : other.Value is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyClanAggregateStat? other)
    {
        if (other is null) return;
        if (Mode != other.Mode)
        {
            Mode = other.Mode;
            OnPropertyChanged(nameof(Mode));
        }
        if (StatId != other.StatId)
        {
            StatId = other.StatId;
            OnPropertyChanged(nameof(StatId));
        }
        if (!Value.DeepEquals(other.Value))
        {
            Value.Update(other.Value);
            OnPropertyChanged(nameof(Value));
        }
    }
}