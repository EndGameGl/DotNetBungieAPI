namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsValue : IDeepEquatable<DestinyHistoricalStatsValue>
{
    /// <summary>
    ///     Unique ID for this stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    /// <summary>
    ///     Basic stat value.
    /// </summary>
    [JsonPropertyName("basic")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Basic { get; set; }

    /// <summary>
    ///     Per game average for the statistic, if applicable
    /// </summary>
    [JsonPropertyName("pga")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Pga { get; set; }

    /// <summary>
    ///     Weighted value of the stat if a weight greater than 1 has been assigned.
    /// </summary>
    [JsonPropertyName("weighted")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValuePair Weighted { get; set; }

    /// <summary>
    ///     When a stat represents the best, most, longest, fastest or some other personal best, the actual activity ID where that personal best was established is available on this property.
    /// </summary>
    [JsonPropertyName("activityId")]
    public long? ActivityId { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsValue? other)
    {
        return other is not null &&
               StatId == other.StatId &&
               (Basic is not null ? Basic.DeepEquals(other.Basic) : other.Basic is null) &&
               (Pga is not null ? Pga.DeepEquals(other.Pga) : other.Pga is null) &&
               (Weighted is not null ? Weighted.DeepEquals(other.Weighted) : other.Weighted is null) &&
               ActivityId == other.ActivityId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsValue? other)
    {
        if (other is null) return;
        if (StatId != other.StatId)
        {
            StatId = other.StatId;
            OnPropertyChanged(nameof(StatId));
        }
        if (!Basic.DeepEquals(other.Basic))
        {
            Basic.Update(other.Basic);
            OnPropertyChanged(nameof(Basic));
        }
        if (!Pga.DeepEquals(other.Pga))
        {
            Pga.Update(other.Pga);
            OnPropertyChanged(nameof(Pga));
        }
        if (!Weighted.DeepEquals(other.Weighted))
        {
            Weighted.Update(other.Weighted);
            OnPropertyChanged(nameof(Weighted));
        }
        if (ActivityId != other.ActivityId)
        {
            ActivityId = other.ActivityId;
            OnPropertyChanged(nameof(ActivityId));
        }
    }
}