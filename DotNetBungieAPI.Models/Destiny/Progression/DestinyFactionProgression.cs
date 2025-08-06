namespace DotNetBungieAPI.Models.Destiny.Progression;

/// <summary>
///     Mostly for historical purposes, we segregate Faction progressions from other progressions. This is just a DestinyProgression with a shortcut for finding the DestinyFactionDefinition of the faction related to the progression.
/// </summary>
public sealed class DestinyFactionProgression
{
    /// <summary>
    ///     The hash identifier of the Faction related to this progression. Use it to look up the DestinyFactionDefinition for more rendering info.
    /// </summary>
    [JsonPropertyName("factionHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyFactionDefinition> FactionHash { get; init; }

    /// <summary>
    ///     The index of the Faction vendor that is currently available. Will be set to -1 if no vendors are available.
    /// </summary>
    [JsonPropertyName("factionVendorIndex")]
    public int FactionVendorIndex { get; init; }

    /// <summary>
    ///     The hash identifier of the Progression in question. Use it to look up the DestinyProgressionDefinition in static data.
    /// </summary>
    [JsonPropertyName("progressionHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyProgressionDefinition> ProgressionHash { get; init; }

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
    ///     This is the total amount of progress obtained overall for this progression (for instance, the total amount of Character Level experience earned)
    /// </summary>
    [JsonPropertyName("currentProgress")]
    public int CurrentProgress { get; init; }

    /// <summary>
    ///     This is the level of the progression (for instance, the Character Level).
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; init; }

    /// <summary>
    ///     This is the maximum possible level you can achieve for this progression (for example, the maximum character level obtainable)
    /// </summary>
    [JsonPropertyName("levelCap")]
    public int LevelCap { get; init; }

    /// <summary>
    ///     Progressions define their levels in "steps". Since the last step may be repeatable, the user may be at a higher level than the actual Step achieved in the progression. Not necessarily useful, but potentially interesting for those cruising the API. Relate this to the "steps" property of the DestinyProgression to see which step the user is on, if you care about that. (Note that this is Content Version dependent since it refers to indexes.)
    /// </summary>
    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; init; }

    /// <summary>
    ///     The amount of progression (i.e. "Experience") needed to reach the next level of this Progression. Jeez, progression is such an overloaded word.
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
    public Destiny.DestinyProgressionResetEntry[]? SeasonResets { get; init; }

    /// <summary>
    ///     Information about historical rewards for this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemStates")]
    public Destiny.DestinyProgressionRewardItemState[]? RewardItemStates { get; init; }

    /// <summary>
    ///     Information about items stats and states that have socket overrides, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemSocketOverrideStates")]
    public Dictionary<int, Destiny.DestinyProgressionRewardItemSocketOverrideState>? RewardItemSocketOverrideStates { get; init; }
}
