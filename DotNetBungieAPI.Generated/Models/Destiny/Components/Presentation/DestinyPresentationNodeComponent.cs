namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Presentation;

public class DestinyPresentationNodeComponent : IDeepEquatable<DestinyPresentationNodeComponent>
{
    [JsonPropertyName("state")]
    public Destiny.DestinyPresentationNodeState State { get; set; }

    /// <summary>
    ///     An optional property: presentation nodes MAY have objectives, which can be used to infer more human readable data about the progress. However, progressValue and completionValue ought to be considered the canonical values for progress on Progression Nodes.
    /// </summary>
    [JsonPropertyName("objective")]
    public Destiny.Quests.DestinyObjectiveProgress Objective { get; set; }

    /// <summary>
    ///     How much of the presentation node is considered to be completed so far by the given character/profile.
    /// </summary>
    [JsonPropertyName("progressValue")]
    public int ProgressValue { get; set; }

    /// <summary>
    ///     The value at which the presentation node is considered to be completed.
    /// </summary>
    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; set; }

    /// <summary>
    ///     If available, this is the current score for the record category that this node represents.
    /// </summary>
    [JsonPropertyName("recordCategoryScore")]
    public int? RecordCategoryScore { get; set; }

    public bool DeepEquals(DestinyPresentationNodeComponent? other)
    {
        return other is not null &&
               State == other.State &&
               (Objective is not null ? Objective.DeepEquals(other.Objective) : other.Objective is null) &&
               ProgressValue == other.ProgressValue &&
               CompletionValue == other.CompletionValue &&
               RecordCategoryScore == other.RecordCategoryScore;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeComponent? other)
    {
        if (other is null) return;
        if (State != other.State)
        {
            State = other.State;
            OnPropertyChanged(nameof(State));
        }
        if (!Objective.DeepEquals(other.Objective))
        {
            Objective.Update(other.Objective);
            OnPropertyChanged(nameof(Objective));
        }
        if (ProgressValue != other.ProgressValue)
        {
            ProgressValue = other.ProgressValue;
            OnPropertyChanged(nameof(ProgressValue));
        }
        if (CompletionValue != other.CompletionValue)
        {
            CompletionValue = other.CompletionValue;
            OnPropertyChanged(nameof(CompletionValue));
        }
        if (RecordCategoryScore != other.RecordCategoryScore)
        {
            RecordCategoryScore = other.RecordCategoryScore;
            OnPropertyChanged(nameof(RecordCategoryScore));
        }
    }
}