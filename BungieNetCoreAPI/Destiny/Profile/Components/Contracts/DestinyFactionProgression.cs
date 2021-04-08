using NetBungieAPI.Destiny.Definitions.Factions;
using NetBungieAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyFactionProgression
    {
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; }
        public int FactionVendorIndex { get; init; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; }
        public int DailyProgress { get; init; }
        public int DailyLimit { get; init; }
        public int WeeklyProgress { get; init; }
        public int WeeklyLimit { get; init; }
        public int CurrentProgress { get; init; }
        public int Level { get; init; }
        public int LevelCap { get; init; }
        public int StepIndex { get; init; }
        public int ProgressToNextLevel { get; init; }
        public int NextLevelAt { get; init; }
        public int? CurrentResetCount { get; init; }
        public ReadOnlyCollection<DestinyProgressionReset> SeasonResets { get; init; }
        public ReadOnlyCollection<DestinyProgressionRewardItemState> RewardItemStates { get; init; }

        [JsonConstructor]
        internal DestinyFactionProgression(uint factionHash,int factionVendorIndex, uint progressionHash, int dailyProgress, int dailyLimit, int weeklyProgress,
            int weeklyLimit, int currentProgress, int level, int levelCap, int stepIndex, int progressToNextLevel, int nextLevelAt, int? currentResetCount,
            DestinyProgressionReset[] seasonResets, DestinyProgressionRewardItemState[] rewardItemStates)
        {
            Faction = new DefinitionHashPointer<DestinyFactionDefinition>(factionHash, DefinitionsEnum.DestinyFactionDefinition);
            FactionVendorIndex = factionVendorIndex;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            DailyProgress = dailyProgress;
            DailyLimit = dailyLimit;
            WeeklyProgress = weeklyProgress;
            WeeklyLimit = weeklyLimit;
            CurrentProgress = currentProgress;
            Level = level;
            LevelCap = levelCap;
            StepIndex = stepIndex;
            ProgressToNextLevel = progressToNextLevel;
            NextLevelAt = nextLevelAt;
            CurrentResetCount = currentResetCount;
            SeasonResets = seasonResets.AsReadOnlyOrEmpty();
            RewardItemStates = rewardItemStates.AsReadOnlyOrEmpty();
        }
    }
}
