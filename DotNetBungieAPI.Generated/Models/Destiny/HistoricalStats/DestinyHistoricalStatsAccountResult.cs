namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyHistoricalStatsAccountResult : IDeepEquatable<DestinyHistoricalStatsAccountResult>
{
    [JsonPropertyName("mergedDeletedCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; set; }

    [JsonPropertyName("mergedAllCharacters")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsWithMerged MergedAllCharacters { get; set; }

    [JsonPropertyName("characters")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPerCharacter> Characters { get; set; }

    public bool DeepEquals(DestinyHistoricalStatsAccountResult? other)
    {
        return other is not null &&
               (MergedDeletedCharacters is not null ? MergedDeletedCharacters.DeepEquals(other.MergedDeletedCharacters) : other.MergedDeletedCharacters is null) &&
               (MergedAllCharacters is not null ? MergedAllCharacters.DeepEquals(other.MergedAllCharacters) : other.MergedAllCharacters is null) &&
               Characters.DeepEqualsList(other.Characters);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyHistoricalStatsAccountResult? other)
    {
        if (other is null) return;
        if (!MergedDeletedCharacters.DeepEquals(other.MergedDeletedCharacters))
        {
            MergedDeletedCharacters.Update(other.MergedDeletedCharacters);
            OnPropertyChanged(nameof(MergedDeletedCharacters));
        }
        if (!MergedAllCharacters.DeepEquals(other.MergedAllCharacters))
        {
            MergedAllCharacters.Update(other.MergedAllCharacters);
            OnPropertyChanged(nameof(MergedAllCharacters));
        }
        if (!Characters.DeepEqualsList(other.Characters))
        {
            Characters = other.Characters;
            OnPropertyChanged(nameof(Characters));
        }
    }
}