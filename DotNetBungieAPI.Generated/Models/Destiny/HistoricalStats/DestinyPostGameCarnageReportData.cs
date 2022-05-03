namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportData : IDeepEquatable<DestinyPostGameCarnageReportData>
{
    /// <summary>
    ///     Date and time for the activity.
    /// </summary>
    [JsonPropertyName("period")]
    public DateTime Period { get; set; }

    /// <summary>
    ///     If this activity has "phases", this is the phase at which the activity was started. This value is only valid for activities before the Beyond Light expansion shipped. Subsequent activities will not have a valid value here.
    /// </summary>
    [JsonPropertyName("startingPhaseIndex")]
    public int? StartingPhaseIndex { get; set; }

    /// <summary>
    ///     True if the activity was started from the beginning, if that information is available and the activity was played post Witch Queen release.
    /// </summary>
    [JsonPropertyName("activityWasStartedFromBeginning")]
    public bool? ActivityWasStartedFromBeginning { get; set; }

    /// <summary>
    ///     Details about the activity.
    /// </summary>
    [JsonPropertyName("activityDetails")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsActivity ActivityDetails { get; set; }

    /// <summary>
    ///     Collection of players and their data for this activity.
    /// </summary>
    [JsonPropertyName("entries")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportEntry> Entries { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("teams")]
    public List<Destiny.HistoricalStats.DestinyPostGameCarnageReportTeamEntry> Teams { get; set; }

    public bool DeepEquals(DestinyPostGameCarnageReportData? other)
    {
        return other is not null &&
               Period == other.Period &&
               StartingPhaseIndex == other.StartingPhaseIndex &&
               ActivityWasStartedFromBeginning == other.ActivityWasStartedFromBeginning &&
               (ActivityDetails is not null ? ActivityDetails.DeepEquals(other.ActivityDetails) : other.ActivityDetails is null) &&
               Entries.DeepEqualsList(other.Entries) &&
               Teams.DeepEqualsList(other.Teams);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPostGameCarnageReportData? other)
    {
        if (other is null) return;
        if (Period != other.Period)
        {
            Period = other.Period;
            OnPropertyChanged(nameof(Period));
        }
        if (StartingPhaseIndex != other.StartingPhaseIndex)
        {
            StartingPhaseIndex = other.StartingPhaseIndex;
            OnPropertyChanged(nameof(StartingPhaseIndex));
        }
        if (ActivityWasStartedFromBeginning != other.ActivityWasStartedFromBeginning)
        {
            ActivityWasStartedFromBeginning = other.ActivityWasStartedFromBeginning;
            OnPropertyChanged(nameof(ActivityWasStartedFromBeginning));
        }
        if (!ActivityDetails.DeepEquals(other.ActivityDetails))
        {
            ActivityDetails.Update(other.ActivityDetails);
            OnPropertyChanged(nameof(ActivityDetails));
        }
        if (!Entries.DeepEqualsList(other.Entries))
        {
            Entries = other.Entries;
            OnPropertyChanged(nameof(Entries));
        }
        if (!Teams.DeepEqualsList(other.Teams))
        {
            Teams = other.Teams;
            OnPropertyChanged(nameof(Teams));
        }
    }
}