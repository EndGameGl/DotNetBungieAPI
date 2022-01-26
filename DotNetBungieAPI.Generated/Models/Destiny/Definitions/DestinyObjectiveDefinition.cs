namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines an "Objective".
/// <para />
///     An objective is a specific task you should accomplish in the game. These are referred to by:
/// <para />
///     - Quest Steps (which are DestinyInventoryItemDefinition entities with Objectives)
/// <para />
///     - Challenges (which are Objectives defined on an DestinyActivityDefintion)
/// <para />
///     - Milestones (which refer to Objectives that are defined on both Quest Steps and Activities)
/// <para />
///     - Anything else that the designers decide to do later.
/// <para />
///     Objectives have progress, a notion of having been Completed, human readable data describing the task to be accomplished, and a lot of optional tack-on data that can enhance the information provided about the task.
/// </summary>
public class DestinyObjectiveDefinition : IDeepEquatable<DestinyObjectiveDefinition>
{
    /// <summary>
    ///     Ideally, this should tell you what your task is. I'm not going to lie to you though. Sometimes this doesn't have useful information at all. Which sucks, but there's nothing either of us can do about it.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The value that the unlock value defined in unlockValueHash must reach in order for the objective to be considered Completed. Used in calculating progress and completion status.
    /// </summary>
    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; set; }

    /// <summary>
    ///     A shortcut for determining the most restrictive gating that this Objective is set to use. This includes both the dynamic determination of progress and of completion values. See the DestinyGatingScope enum's documentation for more details.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyGatingScope Scope { get; set; }

    /// <summary>
    ///     OPTIONAL: a hash identifier for the location at which this objective must be accomplished, if there is a location defined. Look up the DestinyLocationDefinition for this hash for that additional location info.
    /// </summary>
    [JsonPropertyName("locationHash")]
    public uint LocationHash { get; set; }

    /// <summary>
    ///     If true, the value is allowed to go negative.
    /// </summary>
    [JsonPropertyName("allowNegativeValue")]
    public bool AllowNegativeValue { get; set; }

    /// <summary>
    ///     If true, you can effectively "un-complete" this objective if you lose progress after crossing the completion threshold. 
    /// <para />
    ///     If False, once you complete the task it will remain completed forever by locking the value.
    /// </summary>
    [JsonPropertyName("allowValueChangeWhenCompleted")]
    public bool AllowValueChangeWhenCompleted { get; set; }

    /// <summary>
    ///     If true, completion means having an unlock value less than or equal to the completionValue.
    /// <para />
    ///     If False, completion means having an unlock value greater than or equal to the completionValue.
    /// </summary>
    [JsonPropertyName("isCountingDownward")]
    public bool IsCountingDownward { get; set; }

    /// <summary>
    ///     The UI style applied to the objective. It's an enum, take a look at DestinyUnlockValueUIStyle for details of the possible styles. Use this info as you wish to customize your UI.
    /// </summary>
    [JsonPropertyName("valueStyle")]
    public Destiny.DestinyUnlockValueUIStyle ValueStyle { get; set; }

    /// <summary>
    ///     Text to describe the progress bar.
    /// </summary>
    [JsonPropertyName("progressDescription")]
    public string ProgressDescription { get; set; }

    /// <summary>
    ///     If this objective enables Perks intrinsically, the conditions for that enabling are defined here.
    /// </summary>
    [JsonPropertyName("perks")]
    public Destiny.Definitions.DestinyObjectivePerkEntryDefinition Perks { get; set; }

    /// <summary>
    ///     If this objective enables modifications on a player's stats intrinsically, the conditions are defined here.
    /// </summary>
    [JsonPropertyName("stats")]
    public Destiny.Definitions.DestinyObjectiveStatEntryDefinition Stats { get; set; }

    /// <summary>
    ///     If nonzero, this is the minimum value at which the objective's progression should be shown. Otherwise, don't show it yet.
    /// </summary>
    [JsonPropertyName("minimumVisibilityThreshold")]
    public int MinimumVisibilityThreshold { get; set; }

    /// <summary>
    ///     If True, the progress will continue even beyond the point where the objective met its minimum completion requirements. Your UI will have to accommodate it.
    /// </summary>
    [JsonPropertyName("allowOvercompletion")]
    public bool AllowOvercompletion { get; set; }

    /// <summary>
    ///     If True, you should continue showing the progression value in the UI after it's complete. I mean, we already do that in BNet anyways, but if you want to be better behaved than us you could honor this flag.
    /// </summary>
    [JsonPropertyName("showValueOnComplete")]
    public bool ShowValueOnComplete { get; set; }

    /// <summary>
    ///     The style to use when the objective is completed.
    /// </summary>
    [JsonPropertyName("completedValueStyle")]
    public Destiny.DestinyUnlockValueUIStyle CompletedValueStyle { get; set; }

    /// <summary>
    ///     The style to use when the objective is still in progress.
    /// </summary>
    [JsonPropertyName("inProgressValueStyle")]
    public Destiny.DestinyUnlockValueUIStyle InProgressValueStyle { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyObjectiveDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               CompletionValue == other.CompletionValue &&
               Scope == other.Scope &&
               LocationHash == other.LocationHash &&
               AllowNegativeValue == other.AllowNegativeValue &&
               AllowValueChangeWhenCompleted == other.AllowValueChangeWhenCompleted &&
               IsCountingDownward == other.IsCountingDownward &&
               ValueStyle == other.ValueStyle &&
               ProgressDescription == other.ProgressDescription &&
               (Perks is not null ? Perks.DeepEquals(other.Perks) : other.Perks is null) &&
               (Stats is not null ? Stats.DeepEquals(other.Stats) : other.Stats is null) &&
               MinimumVisibilityThreshold == other.MinimumVisibilityThreshold &&
               AllowOvercompletion == other.AllowOvercompletion &&
               ShowValueOnComplete == other.ShowValueOnComplete &&
               CompletedValueStyle == other.CompletedValueStyle &&
               InProgressValueStyle == other.InProgressValueStyle &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyObjectiveDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (CompletionValue != other.CompletionValue)
        {
            CompletionValue = other.CompletionValue;
            OnPropertyChanged(nameof(CompletionValue));
        }
        if (Scope != other.Scope)
        {
            Scope = other.Scope;
            OnPropertyChanged(nameof(Scope));
        }
        if (LocationHash != other.LocationHash)
        {
            LocationHash = other.LocationHash;
            OnPropertyChanged(nameof(LocationHash));
        }
        if (AllowNegativeValue != other.AllowNegativeValue)
        {
            AllowNegativeValue = other.AllowNegativeValue;
            OnPropertyChanged(nameof(AllowNegativeValue));
        }
        if (AllowValueChangeWhenCompleted != other.AllowValueChangeWhenCompleted)
        {
            AllowValueChangeWhenCompleted = other.AllowValueChangeWhenCompleted;
            OnPropertyChanged(nameof(AllowValueChangeWhenCompleted));
        }
        if (IsCountingDownward != other.IsCountingDownward)
        {
            IsCountingDownward = other.IsCountingDownward;
            OnPropertyChanged(nameof(IsCountingDownward));
        }
        if (ValueStyle != other.ValueStyle)
        {
            ValueStyle = other.ValueStyle;
            OnPropertyChanged(nameof(ValueStyle));
        }
        if (ProgressDescription != other.ProgressDescription)
        {
            ProgressDescription = other.ProgressDescription;
            OnPropertyChanged(nameof(ProgressDescription));
        }
        if (!Perks.DeepEquals(other.Perks))
        {
            Perks.Update(other.Perks);
            OnPropertyChanged(nameof(Perks));
        }
        if (!Stats.DeepEquals(other.Stats))
        {
            Stats.Update(other.Stats);
            OnPropertyChanged(nameof(Stats));
        }
        if (MinimumVisibilityThreshold != other.MinimumVisibilityThreshold)
        {
            MinimumVisibilityThreshold = other.MinimumVisibilityThreshold;
            OnPropertyChanged(nameof(MinimumVisibilityThreshold));
        }
        if (AllowOvercompletion != other.AllowOvercompletion)
        {
            AllowOvercompletion = other.AllowOvercompletion;
            OnPropertyChanged(nameof(AllowOvercompletion));
        }
        if (ShowValueOnComplete != other.ShowValueOnComplete)
        {
            ShowValueOnComplete = other.ShowValueOnComplete;
            OnPropertyChanged(nameof(ShowValueOnComplete));
        }
        if (CompletedValueStyle != other.CompletedValueStyle)
        {
            CompletedValueStyle = other.CompletedValueStyle;
            OnPropertyChanged(nameof(CompletedValueStyle));
        }
        if (InProgressValueStyle != other.InProgressValueStyle)
        {
            InProgressValueStyle = other.InProgressValueStyle;
            OnPropertyChanged(nameof(InProgressValueStyle));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}