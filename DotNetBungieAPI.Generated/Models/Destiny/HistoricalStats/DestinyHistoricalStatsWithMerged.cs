namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsWithMerged : IDeepEquatable<DestinyHistoricalStatsWithMerged>
{
    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsWithMerged? other)
    {
        return other is not null &&
               Results.DeepEqualsDictionary(other.Results) &&
               (Merged is not null ? Merged.DeepEquals(other.Merged) : other.Merged is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsWithMerged? other)
    {
        if (other is null) return;
        if (!Results.DeepEqualsDictionary(other.Results))
        {
            Results = other.Results;
            OnPropertyChanged(nameof(Results));
        }
        if (!Merged.DeepEquals(other.Merged))
        {
            Merged.Update(other.Merged);
            OnPropertyChanged(nameof(Merged));
        }
    }
}