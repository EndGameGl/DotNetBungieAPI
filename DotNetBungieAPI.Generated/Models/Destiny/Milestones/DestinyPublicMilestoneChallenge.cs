namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     A Milestone can have many Challenges. Challenges are just extra Objectives that provide a fun way to mix-up play and provide extra rewards.
/// </summary>
public class DestinyPublicMilestoneChallenge : IDeepEquatable<DestinyPublicMilestoneChallenge>
{
    /// <summary>
    ///     The objective for the Challenge, which should have human-readable data about what needs to be done to accomplish the objective. Use this hash to look up the DestinyObjectiveDefinition.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }

    /// <summary>
    ///     IF the Objective is related to a specific Activity, this will be that activity's hash. Use it to look up the DestinyActivityDefinition for additional data to show.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    public bool DeepEquals(DestinyPublicMilestoneChallenge? other)
    {
        return other is not null &&
               ObjectiveHash == other.ObjectiveHash &&
               ActivityHash == other.ActivityHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPublicMilestoneChallenge? other)
    {
        if (other is null) return;
        if (ObjectiveHash != other.ObjectiveHash)
        {
            ObjectiveHash = other.ObjectiveHash;
            OnPropertyChanged(nameof(ObjectiveHash));
        }
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
    }
}