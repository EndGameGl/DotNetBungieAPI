namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     Information about a current character's status with a Progression. A progression is a value that can increase with activity and has levels. Think Character Level and Reputation Levels. Combine this "live" data with the related DestinyProgressionDefinition for a full picture of the Progression.
/// </summary>
public class DestinyProgression : IDeepEquatable<DestinyProgression>
{
    /// <summary>
    ///     The hash identifier of the Progression in question. Use it to look up the DestinyProgressionDefinition in static data.
    /// </summary>
    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; set; }

    /// <summary>
    ///     The amount of progress earned today for this progression.
    /// </summary>
    [JsonPropertyName("dailyProgress")]
    public int DailyProgress { get; set; }

    /// <summary>
    ///     If this progression has a daily limit, this is that limit.
    /// </summary>
    [JsonPropertyName("dailyLimit")]
    public int DailyLimit { get; set; }

    /// <summary>
    ///     The amount of progress earned toward this progression in the current week.
    /// </summary>
    [JsonPropertyName("weeklyProgress")]
    public int WeeklyProgress { get; set; }

    /// <summary>
    ///     If this progression has a weekly limit, this is that limit.
    /// </summary>
    [JsonPropertyName("weeklyLimit")]
    public int WeeklyLimit { get; set; }

    /// <summary>
    ///     This is the total amount of progress obtained overall for this progression (for instance, the total amount of Character Level experience earned)
    /// </summary>
    [JsonPropertyName("currentProgress")]
    public int CurrentProgress { get; set; }

    /// <summary>
    ///     This is the level of the progression (for instance, the Character Level).
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    /// <summary>
    ///     This is the maximum possible level you can achieve for this progression (for example, the maximum character level obtainable)
    /// </summary>
    [JsonPropertyName("levelCap")]
    public int LevelCap { get; set; }

    /// <summary>
    ///     Progressions define their levels in "steps". Since the last step may be repeatable, the user may be at a higher level than the actual Step achieved in the progression. Not necessarily useful, but potentially interesting for those cruising the API. Relate this to the "steps" property of the DestinyProgression to see which step the user is on, if you care about that. (Note that this is Content Version dependent since it refers to indexes.)
    /// </summary>
    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; set; }

    /// <summary>
    ///     The amount of progression (i.e. "Experience") needed to reach the next level of this Progression. Jeez, progression is such an overloaded word.
    /// </summary>
    [JsonPropertyName("progressToNextLevel")]
    public int ProgressToNextLevel { get; set; }

    /// <summary>
    ///     The total amount of progression (i.e. "Experience") needed in order to reach the next level.
    /// </summary>
    [JsonPropertyName("nextLevelAt")]
    public int NextLevelAt { get; set; }

    /// <summary>
    ///     The number of resets of this progression you've executed this season, if applicable to this progression.
    /// </summary>
    [JsonPropertyName("currentResetCount")]
    public int? CurrentResetCount { get; set; }

    /// <summary>
    ///     Information about historical resets of this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("seasonResets")]
    public List<Destiny.DestinyProgressionResetEntry> SeasonResets { get; set; }

    /// <summary>
    ///     Information about historical rewards for this progression, if there is any data for it.
    /// </summary>
    [JsonPropertyName("rewardItemStates")]
    public List<Destiny.DestinyProgressionRewardItemState> RewardItemStates { get; set; }

    public bool DeepEquals(DestinyProgression? other)
    {
        return other is not null &&
               ProgressionHash == other.ProgressionHash &&
               DailyProgress == other.DailyProgress &&
               DailyLimit == other.DailyLimit &&
               WeeklyProgress == other.WeeklyProgress &&
               WeeklyLimit == other.WeeklyLimit &&
               CurrentProgress == other.CurrentProgress &&
               Level == other.Level &&
               LevelCap == other.LevelCap &&
               StepIndex == other.StepIndex &&
               ProgressToNextLevel == other.ProgressToNextLevel &&
               NextLevelAt == other.NextLevelAt &&
               CurrentResetCount == other.CurrentResetCount &&
               SeasonResets.DeepEqualsList(other.SeasonResets) &&
               RewardItemStates.DeepEqualsListNaive(other.RewardItemStates);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProgression? other)
    {
        if (other is null) return;
        if (ProgressionHash != other.ProgressionHash)
        {
            ProgressionHash = other.ProgressionHash;
            OnPropertyChanged(nameof(ProgressionHash));
        }
        if (DailyProgress != other.DailyProgress)
        {
            DailyProgress = other.DailyProgress;
            OnPropertyChanged(nameof(DailyProgress));
        }
        if (DailyLimit != other.DailyLimit)
        {
            DailyLimit = other.DailyLimit;
            OnPropertyChanged(nameof(DailyLimit));
        }
        if (WeeklyProgress != other.WeeklyProgress)
        {
            WeeklyProgress = other.WeeklyProgress;
            OnPropertyChanged(nameof(WeeklyProgress));
        }
        if (WeeklyLimit != other.WeeklyLimit)
        {
            WeeklyLimit = other.WeeklyLimit;
            OnPropertyChanged(nameof(WeeklyLimit));
        }
        if (CurrentProgress != other.CurrentProgress)
        {
            CurrentProgress = other.CurrentProgress;
            OnPropertyChanged(nameof(CurrentProgress));
        }
        if (Level != other.Level)
        {
            Level = other.Level;
            OnPropertyChanged(nameof(Level));
        }
        if (LevelCap != other.LevelCap)
        {
            LevelCap = other.LevelCap;
            OnPropertyChanged(nameof(LevelCap));
        }
        if (StepIndex != other.StepIndex)
        {
            StepIndex = other.StepIndex;
            OnPropertyChanged(nameof(StepIndex));
        }
        if (ProgressToNextLevel != other.ProgressToNextLevel)
        {
            ProgressToNextLevel = other.ProgressToNextLevel;
            OnPropertyChanged(nameof(ProgressToNextLevel));
        }
        if (NextLevelAt != other.NextLevelAt)
        {
            NextLevelAt = other.NextLevelAt;
            OnPropertyChanged(nameof(NextLevelAt));
        }
        if (CurrentResetCount != other.CurrentResetCount)
        {
            CurrentResetCount = other.CurrentResetCount;
            OnPropertyChanged(nameof(CurrentResetCount));
        }
        if (!SeasonResets.DeepEqualsList(other.SeasonResets))
        {
            SeasonResets = other.SeasonResets;
            OnPropertyChanged(nameof(SeasonResets));
        }
        if (!RewardItemStates.DeepEqualsListNaive(other.RewardItemStates))
        {
            RewardItemStates = other.RewardItemStates;
            OnPropertyChanged(nameof(RewardItemStates));
        }
    }
}