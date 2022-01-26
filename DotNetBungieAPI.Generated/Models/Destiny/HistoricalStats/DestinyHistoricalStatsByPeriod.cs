namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsByPeriod : IDeepEquatable<DestinyHistoricalStatsByPeriod>
{
    [JsonPropertyName("allTime")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTime { get; set; }

    [JsonPropertyName("allTimeTier1")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTimeTier1 { get; set; }

    [JsonPropertyName("allTimeTier2")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTimeTier2 { get; set; }

    [JsonPropertyName("allTimeTier3")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> AllTimeTier3 { get; set; }

    [JsonPropertyName("daily")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Daily { get; set; }

    [JsonPropertyName("monthly")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Monthly { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsByPeriod? other)
    {
        return other is not null &&
               AllTime.DeepEqualsDictionary(other.AllTime) &&
               AllTimeTier1.DeepEqualsDictionary(other.AllTimeTier1) &&
               AllTimeTier2.DeepEqualsDictionary(other.AllTimeTier2) &&
               AllTimeTier3.DeepEqualsDictionary(other.AllTimeTier3) &&
               Daily.DeepEqualsList(other.Daily) &&
               Monthly.DeepEqualsList(other.Monthly);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsByPeriod? other)
    {
        if (other is null) return;
        if (!AllTime.DeepEqualsDictionary(other.AllTime))
        {
            AllTime = other.AllTime;
            OnPropertyChanged(nameof(AllTime));
        }
        if (!AllTimeTier1.DeepEqualsDictionary(other.AllTimeTier1))
        {
            AllTimeTier1 = other.AllTimeTier1;
            OnPropertyChanged(nameof(AllTimeTier1));
        }
        if (!AllTimeTier2.DeepEqualsDictionary(other.AllTimeTier2))
        {
            AllTimeTier2 = other.AllTimeTier2;
            OnPropertyChanged(nameof(AllTimeTier2));
        }
        if (!AllTimeTier3.DeepEqualsDictionary(other.AllTimeTier3))
        {
            AllTimeTier3 = other.AllTimeTier3;
            OnPropertyChanged(nameof(AllTimeTier3));
        }
        if (!Daily.DeepEqualsList(other.Daily))
        {
            Daily = other.Daily;
            OnPropertyChanged(nameof(Daily));
        }
        if (!Monthly.DeepEqualsList(other.Monthly))
        {
            Monthly = other.Monthly;
            OnPropertyChanged(nameof(Monthly));
        }
    }
}