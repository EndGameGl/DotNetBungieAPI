namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyAggregateActivityResults : IDeepEquatable<DestinyAggregateActivityResults>
{
    /// <summary>
    ///     List of all activities the player has participated in.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyAggregateActivityStats> Activities { get; set; }

    public bool DeepEquals(DestinyAggregateActivityResults? other)
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

    public void Update(DestinyAggregateActivityResults? other)
    {
        if (other is null) return;
        if (!Activities.DeepEqualsList(other.Activities))
        {
            Activities = other.Activities;
            OnPropertyChanged(nameof(Activities));
        }
    }
}