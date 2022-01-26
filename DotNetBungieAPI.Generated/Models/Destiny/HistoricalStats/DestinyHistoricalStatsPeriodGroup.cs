namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsPeriodGroup : IDeepEquatable<DestinyHistoricalStatsPeriodGroup>
{
    /// <summary>
    ///     Period for the group. If the stat periodType is day, then this will have a specific day. If the type is monthly, then this value will be the first day of the applicable month. This value is not set when the periodType is 'all time'.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>
    ///     If the period group is for a specific activity, this property will be set.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; set; }

    /// <summary>
    ///     Collection of stats for the period.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsPeriodGroup? other)
    {
        return other is not null &&
               Period == other.Period &&
               (ActivityDetails is not null ? ActivityDetails.DeepEquals(other.ActivityDetails) : other.ActivityDetails is null) &&
               Values.DeepEqualsDictionary(other.Values);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsPeriodGroup? other)
    {
        if (other is null) return;
        if (Period != other.Period)
        {
            Period = other.Period;
            OnPropertyChanged(nameof(Period));
        }
        if (!ActivityDetails.DeepEquals(other.ActivityDetails))
        {
            ActivityDetails.Update(other.ActivityDetails);
            OnPropertyChanged(nameof(ActivityDetails));
        }
        if (!Values.DeepEqualsDictionary(other.Values))
        {
            Values = other.Values;
            OnPropertyChanged(nameof(Values));
        }
    }
}