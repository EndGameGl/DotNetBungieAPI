using DotNetBungieAPI.Models.Destiny.Definitions.Progressions;

namespace DotNetBungieAPI.Models.Destiny.Progressions;

/// <summary>
///     Information about a current character's status with a Progression. A progression is a value that can increase with
///     activity and has levels. Think Character Level and Reputation Levels. Combine this "live" data with the related
///     DestinyProgressionDefinition for a full picture of the Progression.
/// </summary>
public record DestinyProgression
{
    /// <summary>
    ///     DestinyProgressionDefinition in question.
    /// </summary>
    [JsonPropertyName("progressionHash")]
    public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } =
        DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

    /// <summary>
    ///     The amount of progress earned today for this progression.
    /// </summary>
    [JsonPropertyName("dailyProgress")]
    public int DailyProgress { get; init; }

    /// <summary>
    ///     If this progression has a daily limit, this is that limit.
    /// </summary>
    [JsonPropertyName("dailyLimit")]
    public int DailyLimit { get; init; }

    /// <summary>
    ///     The amount of progress earned toward this progression in the current week.
    /// </summary>
    [JsonPropertyName("weeklyProgress")]
    public int WeeklyProgress { get; init; }

    /// <summary>
    ///     If this progression has a weekly limit, this is that limit.
    /// </summary>
    [JsonPropertyName("weeklyLimit")]
    public int WeeklyLimit { get; init; }

    /// <summary>
    ///     This is the total amount of progress obtained overall for this progression (for instance, the total amount of
    ///     Character Level experience earned)
    /// </summary>
    [JsonPropertyName("currentProgress")]
    public int CurrentProgress { get; init; }

    /// <summary>
    ///     This is the level of the progression (for instance, the Character Level).
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; init; }

    /// <summary>
    ///     This is the maximum possible level you can achieve for this progression (for example, the maximum character level
    ///     obtainable)
    /// </summary>
    [JsonPropertyName("levelCap")]
    public int LevelCap { get; init; }

    /// <summary>
    ///     Progressions define their levels in "steps". Since the last step may be repeatable, the user may be at a higher
    ///     level than the actual Step achieved in the progression. Not necessarily useful, but potentially interesting for
    ///     those cruising the API. Relate this to the "steps" property of the DestinyProgression to see which step the user is
    ///     on, if you care about that. (Note that this is Content Version dependent since it refers to indexes.)
    /// </summary>
    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; init; }

    /// <summary>
    ///     The amount of progression (i.e. "Experience") needed to reach the next level of this Progression. Jeez, progression
    ///     is such an overloaded word.
    /// </summary>
    [JsonPropertyName("progressToNextLevel")]
    public int ProgressToNextLevel { get; init; }

    /// <summary>
    ///     The total amount of progression (i.e. "Experience") needed in order to reach the next level.
    /// </summary>
    [JsonPropertyName("nextLevelAt")]
    public int NextLevelAt { get; init; }

    /// <summary>
    ///     The number of resets of this progression you've executed this season, if applicable to this progression.
    /// </summary>
    [JsonPropertyName("currentResetCount")]
    public int? CurrentResetCount { get; init; }

    /// <summary>
    ///     Information about historical resets of this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("seasonResets")]
    public ReadOnlyCollection<DestinyProgressionResetEntry> SeasonResets { get; init; } =
        ReadOnlyCollection<DestinyProgressionResetEntry>.Empty;

    /// <summary>
    ///     Information about historical rewards for this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemStates")]
    public ReadOnlyCollection<DestinyProgressionRewardItemState> RewardItemStates { get; init; } =
        ReadOnlyCollection<DestinyProgressionRewardItemState>.Empty;

    /// <summary>
    ///     Information about items stats and states that have socket overrides, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemSocketOverrideStates")]
    public ReadOnlyDictionary<
        int,
        DestinyProgressionRewardItemSocketOverrideState
    > RewardItemSocketOverrideStates { get; init; } =
        ReadOnlyDictionary<int, DestinyProgressionRewardItemSocketOverrideState>.Empty;
}
