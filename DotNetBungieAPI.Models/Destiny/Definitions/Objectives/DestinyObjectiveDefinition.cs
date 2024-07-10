using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Locations;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

/// <summary>
///     Defines an "Objective".
///     <para />
///     An objective is a specific task you should accomplish in the game.These are referred to by:
///     <para />
///     - Quest Steps (which are DestinyInventoryItemDefinition entities with Objectives)
///     <para />
///     - Challenges(which are Objectives defined on an DestinyActivityDefintion)
///     <para />
///     - Milestones(which refer to Objectives that are defined on both Quest Steps and Activities)
///     <para />
///     - Anything else that the designers decide to do later.
///     <para />
///     Objectives have progress, a notion of having been Completed, human readable data describing the task to be
///     accomplished, and a lot of optional tack-on data that can enhance the information provided about the task.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyObjectiveDefinition)]
public sealed record DestinyObjectiveDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyObjectiveDefinition>
{
    /// <summary>
    ///     Ideally, this should tell you what your task is. I'm not going to lie to you though. Sometimes this doesn't have useful information at all. Which sucks, but there's nothing either of us can do about it.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The value that the unlock value defined in unlockValueHash must reach in order for the objective to be considered
    ///     Completed. Used in calculating progress and completion status.
    /// </summary>
    [JsonPropertyName("completionValue")]
    public int CompletionValue { get; init; }

    /// <summary>
    ///     A shortcut for determining the most restrictive gating that this Objective is set to use. This includes both the
    ///     dynamic determination of progress and of completion values.
    /// </summary>
    [JsonPropertyName("scope")]
    public DestinyGatingScope Scope { get; init; }

    /// <summary>
    ///     The location at which this objective must be accomplished
    /// </summary>
    [JsonPropertyName("locationHash")]
    public DefinitionHashPointer<DestinyLocationDefinition> Location { get; init; } =
        DefinitionHashPointer<DestinyLocationDefinition>.Empty;

    /// <summary>
    ///     If true, the value is allowed to go negative.
    /// </summary>
    [JsonPropertyName("allowNegativeValue")]
    public bool AllowNegativeValue { get; init; }

    /// <summary>
    ///     If true, you can effectively "un-complete" this objective if you lose progress after crossing the completion
    ///     threshold.
    ///     <para />
    ///     If False, once you complete the task it will remain completed forever by locking the value.
    /// </summary>
    [JsonPropertyName("allowValueChangeWhenCompleted")]
    public bool AllowValueChangeWhenCompleted { get; init; }

    /// <summary>
    ///     If true, completion means having an unlock value less than or equal to the completionValue.
    ///     <para />
    ///     If False, completion means having an unlock value greater than or equal to the completionValue
    /// </summary>
    [JsonPropertyName("isCountingDownward")]
    public bool IsCountingDownward { get; init; }

    /// <summary>
    ///     The UI style applied to the objective. It's an enum, take a look at DestinyUnlockValueUIStyle for details of the
    ///     possible styles. Use this info as you wish to customize your UI.
    /// </summary>
    [Obsolete(
        "This is no longer populated by Destiny 2 game content. Please use InProgressValueStyle and CompletedValueStyle instead."
    )]
    [JsonPropertyName("valueStyle")]
    public DestinyUnlockValueUiStyle ValueStyle { get; init; }

    /// <summary>
    ///     Text to describe the progress bar.
    /// </summary>
    [JsonPropertyName("progressDescription")]
    public string ProgressDescription { get; init; }

    /// <summary>
    ///     If this objective enables Perks intrinsically, the conditions for that enabling are defined here.
    /// </summary>
    [JsonPropertyName("perks")]
    public DestinyObjectivePerkEntryDefinition Perks { get; init; }

    /// <summary>
    ///     If this objective enables modifications on a player's stats intrinsically, the conditions are defined here.
    /// </summary>
    [JsonPropertyName("stats")]
    public DestinyObjectiveStatEntryDefinition Stats { get; init; }

    /// <summary>
    ///     If nonzero, this is the minimum value at which the objective's progression should be shown. Otherwise, don't show
    ///     it yet.
    /// </summary>
    [JsonPropertyName("minimumVisibilityThreshold")]
    public int MinimumVisibilityThreshold { get; init; }

    /// <summary>
    ///     If True, the progress will continue even beyond the point where the objective met its minimum completion
    ///     requirements. Your UI will have to accommodate it.
    /// </summary>
    [JsonPropertyName("allowOvercompletion")]
    public bool AllowOvercompletion { get; init; }

    /// <summary>
    ///     If True, you should continue showing the progression value in the UI after it's complete. I mean, we already do
    ///     that in BNet anyways, but if you want to be better behaved than us you could honor this flag.
    /// </summary>
    [JsonPropertyName("showValueOnComplete")]
    public bool ShowValueOnComplete { get; init; }

    /// <summary>
    ///     The style to use when the objective is completed.
    /// </summary>
    [JsonPropertyName("completedValueStyle")]
    public DestinyUnlockValueUiStyle CompletedValueStyle { get; init; }

    /// <summary>
    ///     The style to use when the objective is still in progress.
    /// </summary>
    [JsonPropertyName("inProgressValueStyle")]
    public DestinyUnlockValueUiStyle InProgressValueStyle { get; init; }

    /// <summary>
    ///     Objectives can have arbitrary UI-defined identifiers that define the style applied to objectives. For convenience, known UI labels will be defined in the uiStyle enum value.
    /// </summary>
    [JsonPropertyName("uiLabel")]
    public string UiLabel { get; init; }

    /// <summary>
    ///     If the objective has a known UI label value, this property will represent it.
    /// </summary>
    [JsonPropertyName("uiStyle")]
    public DestinyObjectiveUiStyle UiStyle { get; init; }

    [JsonPropertyName("isDisplayOnlyObjective")]
    public bool IsDisplayOnlyObjective { get; init; }

    public bool DeepEquals(DestinyObjectiveDefinition other)
    {
        return other != null
            && AllowNegativeValue == other.AllowNegativeValue
            && AllowOvercompletion == other.AllowOvercompletion
            && AllowValueChangeWhenCompleted == other.AllowValueChangeWhenCompleted
            && CompletionValue == other.CompletionValue
            && IsCountingDownward == other.IsCountingDownward
            && IsDisplayOnlyObjective == other.IsDisplayOnlyObjective
            && Location.DeepEquals(other.Location)
            && MinimumVisibilityThreshold == other.MinimumVisibilityThreshold
            && ProgressDescription == other.ProgressDescription
            && Scope == other.Scope
            && ShowValueOnComplete == other.ShowValueOnComplete
            && (Perks is not null ? Perks.DeepEquals(other.Perks) : other is null)
            && (Stats is not null ? Stats.DeepEquals(other.Stats) : other is null)
            && ValueStyle == other.ValueStyle
            && CompletedValueStyle == other.CompletedValueStyle
            && InProgressValueStyle == other.InProgressValueStyle
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && UiLabel == other.UiLabel
            && UiStyle == other.UiStyle
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyObjectiveDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
