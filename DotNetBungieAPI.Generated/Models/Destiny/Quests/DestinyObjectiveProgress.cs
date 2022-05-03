namespace DotNetBungieAPI.Generated.Models.Destiny.Quests;

/// <summary>
///     Returns data about a character's status with a given Objective. Combine with DestinyObjectiveDefinition static data for display purposes.
/// </summary>
public class DestinyObjectiveProgress : IDeepEquatable<DestinyObjectiveProgress>
{
    /// <summary>
    ///     The unique identifier of the Objective being referred to. Use to look up the DestinyObjectiveDefinition in static data.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }

    /// <summary>
    ///     If the Objective has a Destination associated with it, this is the unique identifier of the Destination being referred to. Use to look up the DestinyDestinationDefinition in static data. This will give localized data about *where* in the universe the objective should be achieved.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint? DestinationHash { get; set; }

    /// <summary>
    ///     If the Objective has an Activity associated with it, this is the unique identifier of the Activity being referred to. Use to look up the DestinyActivityDefinition in static data. This will give localized data about *what* you should be playing for the objective to be achieved.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    /// <summary>
    ///     If progress has been made, and the progress can be measured numerically, this will be the value of that progress. You can compare it to the DestinyObjectiveDefinition.completionValue property for current vs. upper bounds, and use DestinyObjectiveDefinition.inProgressValueStyle or completedValueStyle to determine how this should be rendered. Note that progress, in Destiny 2, need not be a literal numeric progression. It could be one of a number of possible values, even a Timestamp. Always examine DestinyObjectiveDefinition.inProgressValueStyle or completedValueStyle before rendering progress.
    /// </summary>
    [JsonPropertyName("progress")]
    public int? Progress { get; set; }

    /// <summary>
    ///     As of Forsaken, objectives' completion value is determined dynamically at runtime.
    /// <para />
    ///     This value represents the threshold of progress you need to surpass in order for this objective to be considered "complete".
    /// <para />
    ///     If you were using objective data, switch from using the DestinyObjectiveDefinition's "completionValue" to this value.
    /// </summary>
    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; set; }

    /// <summary>
    ///     Whether or not the Objective is completed.
    /// </summary>
    [JsonPropertyName("complete")]
    public bool Complete { get; set; }

    /// <summary>
    ///     If this is true, the objective is visible in-game. Otherwise, it's not yet visible to the player. Up to you if you want to honor this property.
    /// </summary>
    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    public bool DeepEquals(DestinyObjectiveProgress? other)
    {
        return other is not null &&
               ObjectiveHash == other.ObjectiveHash &&
               DestinationHash == other.DestinationHash &&
               ActivityHash == other.ActivityHash &&
               Progress == other.Progress &&
               CompletionValue == other.CompletionValue &&
               Complete == other.Complete &&
               Visible == other.Visible;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyObjectiveProgress? other)
    {
        if (other is null) return;
        if (ObjectiveHash != other.ObjectiveHash)
        {
            ObjectiveHash = other.ObjectiveHash;
            OnPropertyChanged(nameof(ObjectiveHash));
        }
        if (DestinationHash != other.DestinationHash)
        {
            DestinationHash = other.DestinationHash;
            OnPropertyChanged(nameof(DestinationHash));
        }
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (Progress != other.Progress)
        {
            Progress = other.Progress;
            OnPropertyChanged(nameof(Progress));
        }
        if (CompletionValue != other.CompletionValue)
        {
            CompletionValue = other.CompletionValue;
            OnPropertyChanged(nameof(CompletionValue));
        }
        if (Complete != other.Complete)
        {
            Complete = other.Complete;
            OnPropertyChanged(nameof(Complete));
        }
        if (Visible != other.Visible)
        {
            Visible = other.Visible;
            OnPropertyChanged(nameof(Visible));
        }
    }
}