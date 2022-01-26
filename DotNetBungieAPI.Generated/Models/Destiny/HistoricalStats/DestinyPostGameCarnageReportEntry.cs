namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportEntry : IDeepEquatable<DestinyPostGameCarnageReportEntry>
{
    /// <summary>
    ///     Standing of the player
    /// </summary>
    [JsonPropertyName("standing")]
    public int Standing { get; set; }

    /// <summary>
    ///     Score of the player if available
    /// </summary>
    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; set; }

    /// <summary>
    ///     Identity details of the player
    /// </summary>
    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; set; }

    /// <summary>
    ///     ID of the player's character used in the activity.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    /// <summary>
    ///     Extended data extracted from the activity blob.
    /// </summary>
    [JsonPropertyName("extended")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportExtendedData Extended { get; set; }

    public bool DeepEquals(DestinyPostGameCarnageReportEntry? other)
    {
        return other is not null &&
               Standing == other.Standing &&
               (Score is not null ? Score.DeepEquals(other.Score) : other.Score is null) &&
               (Player is not null ? Player.DeepEquals(other.Player) : other.Player is null) &&
               CharacterId == other.CharacterId &&
               Values.DeepEqualsDictionary(other.Values) &&
               (Extended is not null ? Extended.DeepEquals(other.Extended) : other.Extended is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPostGameCarnageReportEntry? other)
    {
        if (other is null) return;
        if (Standing != other.Standing)
        {
            Standing = other.Standing;
            OnPropertyChanged(nameof(Standing));
        }
        if (!Score.DeepEquals(other.Score))
        {
            Score.Update(other.Score);
            OnPropertyChanged(nameof(Score));
        }
        if (!Player.DeepEquals(other.Player))
        {
            Player.Update(other.Player);
            OnPropertyChanged(nameof(Player));
        }
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (!Values.DeepEqualsDictionary(other.Values))
        {
            Values = other.Values;
            OnPropertyChanged(nameof(Values));
        }
        if (!Extended.DeepEquals(other.Extended))
        {
            Extended.Update(other.Extended);
            OnPropertyChanged(nameof(Extended));
        }
    }
}