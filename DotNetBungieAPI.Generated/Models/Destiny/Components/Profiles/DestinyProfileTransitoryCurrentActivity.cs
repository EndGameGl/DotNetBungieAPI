namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

/// <summary>
///     If you are playing in an activity, this is some information about it.
/// <para />
///     Note that we cannot guarantee any of this resembles what ends up in the PGCR in any way. They are sourced by two entirely separate systems with their own logic, and the one we source this data from should be considered non-authoritative in comparison.
/// </summary>
public class DestinyProfileTransitoryCurrentActivity : IDeepEquatable<DestinyProfileTransitoryCurrentActivity>
{
    /// <summary>
    ///     When the activity started.
    /// </summary>
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    /// <summary>
    ///     If you're still in it but it "ended" (like when folks are dancing around the loot after they beat a boss), this is when the activity ended.
    /// </summary>
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    /// <summary>
    ///     This is what our non-authoritative source thought the score was.
    /// </summary>
    [JsonPropertyName("score")]
    public float Score { get; set; }

    /// <summary>
    ///     If you have human opponents, this is the highest opposing team's score.
    /// </summary>
    [JsonPropertyName("highestOpposingFactionScore")]
    public float HighestOpposingFactionScore { get; set; }

    /// <summary>
    ///     This is how many human or poorly crafted aimbot opponents you have.
    /// </summary>
    [JsonPropertyName("numberOfOpponents")]
    public int NumberOfOpponents { get; set; }

    /// <summary>
    ///     This is how many human or poorly crafted aimbots are on your team.
    /// </summary>
    [JsonPropertyName("numberOfPlayers")]
    public int NumberOfPlayers { get; set; }

    public bool DeepEquals(DestinyProfileTransitoryCurrentActivity? other)
    {
        return other is not null &&
               StartTime == other.StartTime &&
               EndTime == other.EndTime &&
               Score == other.Score &&
               HighestOpposingFactionScore == other.HighestOpposingFactionScore &&
               NumberOfOpponents == other.NumberOfOpponents &&
               NumberOfPlayers == other.NumberOfPlayers;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProfileTransitoryCurrentActivity? other)
    {
        if (other is null) return;
        if (StartTime != other.StartTime)
        {
            StartTime = other.StartTime;
            OnPropertyChanged(nameof(StartTime));
        }
        if (EndTime != other.EndTime)
        {
            EndTime = other.EndTime;
            OnPropertyChanged(nameof(EndTime));
        }
        if (Score != other.Score)
        {
            Score = other.Score;
            OnPropertyChanged(nameof(Score));
        }
        if (HighestOpposingFactionScore != other.HighestOpposingFactionScore)
        {
            HighestOpposingFactionScore = other.HighestOpposingFactionScore;
            OnPropertyChanged(nameof(HighestOpposingFactionScore));
        }
        if (NumberOfOpponents != other.NumberOfOpponents)
        {
            NumberOfOpponents = other.NumberOfOpponents;
            OnPropertyChanged(nameof(NumberOfOpponents));
        }
        if (NumberOfPlayers != other.NumberOfPlayers)
        {
            NumberOfPlayers = other.NumberOfPlayers;
            OnPropertyChanged(nameof(NumberOfPlayers));
        }
    }
}