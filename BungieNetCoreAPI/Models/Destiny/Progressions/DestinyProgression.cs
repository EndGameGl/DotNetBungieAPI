using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Progressions
{
    public record DestinyProgression
    {
        [JsonPropertyName("progressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } = DefinitionHashPointer<DestinyProgressionDefinition>.Empty;
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
        public ReadOnlyCollection<DestinyProgressionReset> SeasonResets { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyProgressionReset>();
        [JsonPropertyName("rewardItemStates")]
        public ReadOnlyCollection<DestinyProgressionRewardItemState> RewardItemStates { get; init; }
    }
}
