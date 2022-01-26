namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportTeamEntry : IDeepEquatable<DestinyPostGameCarnageReportTeamEntry>
{
    /// <summary>
    ///     Integer ID for the team.
    /// </summary>
    [JsonPropertyName("teamId")]
    public int TeamId { get; set; }

    /// <summary>
    ///     Team's standing relative to other teams.
    /// </summary>
    [JsonPropertyName("standing")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Standing { get; set; }

    /// <summary>
    ///     Score earned by the team
    /// </summary>
    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; set; }

    /// <summary>
    ///     Alpha or Bravo
    /// </summary>
    [JsonPropertyName("teamName")]
    public string TeamName { get; set; }

    public bool DeepEquals(DestinyPostGameCarnageReportTeamEntry? other)
    {
        return other is not null &&
               TeamId == other.TeamId &&
               (Standing is not null ? Standing.DeepEquals(other.Standing) : other.Standing is null) &&
               (Score is not null ? Score.DeepEquals(other.Score) : other.Score is null) &&
               TeamName == other.TeamName;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPostGameCarnageReportTeamEntry? other)
    {
        if (other is null) return;
        if (TeamId != other.TeamId)
        {
            TeamId = other.TeamId;
            OnPropertyChanged(nameof(TeamId));
        }
        if (!Standing.DeepEquals(other.Standing))
        {
            Standing.Update(other.Standing);
            OnPropertyChanged(nameof(Standing));
        }
        if (!Score.DeepEquals(other.Score))
        {
            Score.Update(other.Score);
            OnPropertyChanged(nameof(Score));
        }
        if (TeamName != other.TeamName)
        {
            TeamName = other.TeamName;
            OnPropertyChanged(nameof(TeamName));
        }
    }
}