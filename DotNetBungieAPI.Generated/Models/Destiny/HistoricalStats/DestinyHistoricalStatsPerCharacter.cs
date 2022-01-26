namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsPerCharacter : IDeepEquatable<DestinyHistoricalStatsPerCharacter>
{
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }

    [JsonPropertyName("results")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod> Results { get; set; }

    [JsonPropertyName("merged")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsByPeriod Merged { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsPerCharacter? other)
    {
        return other is not null &&
               CharacterId == other.CharacterId &&
               Deleted == other.Deleted &&
               Results.DeepEqualsDictionary(other.Results) &&
               (Merged is not null ? Merged.DeepEquals(other.Merged) : other.Merged is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsPerCharacter? other)
    {
        if (other is null) return;
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (Deleted != other.Deleted)
        {
            Deleted = other.Deleted;
            OnPropertyChanged(nameof(Deleted));
        }
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