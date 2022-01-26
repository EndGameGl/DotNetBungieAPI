namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyActivityHistoryResults : IDeepEquatable<DestinyActivityHistoryResults>
{
    /// <summary>
    ///     List of activities, the most recent activity first.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Activities { get; set; }

    public bool DeepEquals(DestinyActivityHistoryResults? other)
    {
        return other is not null &&
               Activities.DeepEqualsList(other.Activities);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityHistoryResults? other)
    {
        if (other is null) return;
        if (!Activities.DeepEqualsList(other.Activities))
        {
            Activities = other.Activities;
            OnPropertyChanged(nameof(Activities));
        }
    }
}