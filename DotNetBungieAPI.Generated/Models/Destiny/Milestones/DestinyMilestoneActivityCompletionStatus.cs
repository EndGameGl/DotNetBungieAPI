namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Represents this player's personal completion status for the Activity under a Milestone, if the activity has trackable completion and progress information. (most activities won't, or the concept won't apply. For instance, it makes sense to talk about a tier of a raid as being Completed or having progress, but it doesn't make sense to talk about a Crucible Playlist in those terms.
/// </summary>
public class DestinyMilestoneActivityCompletionStatus : IDeepEquatable<DestinyMilestoneActivityCompletionStatus>
{
    /// <summary>
    ///     If the activity has been "completed", that information will be returned here.
    /// </summary>
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }

    /// <summary>
    ///     If the Activity has discrete "phases" that we can track, that info will be here. Otherwise, this value will be NULL. Note that this is a list and not a dictionary: the order implies the ascending order of phases or progression in this activity.
    /// </summary>
    [JsonPropertyName("phases")]
    public List<Destiny.Milestones.DestinyMilestoneActivityPhase> Phases { get; set; }

    public bool DeepEquals(DestinyMilestoneActivityCompletionStatus? other)
    {
        return other is not null &&
               Completed == other.Completed &&
               Phases.DeepEqualsList(other.Phases);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneActivityCompletionStatus? other)
    {
        if (other is null) return;
        if (Completed != other.Completed)
        {
            Completed = other.Completed;
            OnPropertyChanged(nameof(Completed));
        }
        if (!Phases.DeepEqualsList(other.Phases))
        {
            Phases = other.Phases;
            OnPropertyChanged(nameof(Phases));
        }
    }
}