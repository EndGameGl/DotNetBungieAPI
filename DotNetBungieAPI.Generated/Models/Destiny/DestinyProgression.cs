using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny;

public sealed class DestinyProgression
{

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; init; }

    [JsonPropertyName("dailyProgress")]
    public int DailyProgress { get; init; }

    [JsonPropertyName("dailyLimit")]
    public int DailyLimit { get; init; }

    [JsonPropertyName("weeklyProgress")]
    public int WeeklyProgress { get; init; }

    [JsonPropertyName("weeklyLimit")]
    public int WeeklyLimit { get; init; }

    [JsonPropertyName("currentProgress")]
    public int CurrentProgress { get; init; }

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("levelCap")]
    public int LevelCap { get; init; }

    [JsonPropertyName("stepIndex")]
    public int StepIndex { get; init; }

    [JsonPropertyName("progressToNextLevel")]
    public int ProgressToNextLevel { get; init; }

    [JsonPropertyName("nextLevelAt")]
    public int NextLevelAt { get; init; }

    [JsonPropertyName("currentResetCount")]
    public int? CurrentResetCount { get; init; }

    [JsonPropertyName("seasonResets")]
    public List<Destiny.DestinyProgressionResetEntry> SeasonResets { get; init; }

    [JsonPropertyName("rewardItemStates")]
    public List<Destiny.DestinyProgressionRewardItemState> RewardItemStates { get; init; }
}
