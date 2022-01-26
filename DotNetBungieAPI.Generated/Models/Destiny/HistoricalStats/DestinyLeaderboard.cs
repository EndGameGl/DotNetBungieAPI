namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyLeaderboard : IDeepEquatable<DestinyLeaderboard>
{
    [JsonPropertyName("statId")]
    public string StatId { get; set; }

    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyLeaderboardEntry> Entries { get; set; }

    public bool DeepEquals(DestinyLeaderboard? other)
    {
        return other is not null &&
               StatId == other.StatId &&
               Entries.DeepEqualsList(other.Entries);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyLeaderboard? other)
    {
        if (other is null) return;
        if (StatId != other.StatId)
        {
            StatId = other.StatId;
            OnPropertyChanged(nameof(StatId));
        }
        if (!Entries.DeepEqualsList(other.Entries))
        {
            Entries = other.Entries;
            OnPropertyChanged(nameof(Entries));
        }
    }
}