namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeActivityDefinition : IDeepEquatable<DestinyMilestoneChallengeActivityDefinition>
{
    /// <summary>
    ///     The activity for which this challenge is active.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeDefinition> Challenges { get; set; }

    /// <summary>
    ///     If the activity and its challenge is visible on any of these nodes, it will be returned.
    /// </summary>
    [JsonPropertyName("activityGraphNodes")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityGraphNodeEntry> ActivityGraphNodes { get; set; }

    /// <summary>
    ///     Phases related to this activity, if there are any.
    /// <para />
    ///     These will be listed in the order in which they will appear in the actual activity.
    /// </summary>
    [JsonPropertyName("phases")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityPhase> Phases { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeActivityDefinition? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               Challenges.DeepEqualsList(other.Challenges) &&
               ActivityGraphNodes.DeepEqualsList(other.ActivityGraphNodes) &&
               Phases.DeepEqualsList(other.Phases);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneChallengeActivityDefinition? other)
    {
        if (other is null) return;
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (!Challenges.DeepEqualsList(other.Challenges))
        {
            Challenges = other.Challenges;
            OnPropertyChanged(nameof(Challenges));
        }
        if (!ActivityGraphNodes.DeepEqualsList(other.ActivityGraphNodes))
        {
            ActivityGraphNodes = other.ActivityGraphNodes;
            OnPropertyChanged(nameof(ActivityGraphNodes));
        }
        if (!Phases.DeepEqualsList(other.Phases))
        {
            Phases = other.Phases;
            OnPropertyChanged(nameof(Phases));
        }
    }
}