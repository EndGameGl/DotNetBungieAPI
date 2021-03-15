using NetBungieAPI.Destiny.Definitions.Factions;
using NetBungieAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyFactionProgression
    {
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; }
        public int FactionVendorIndex { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public int DailyProgress { get; }
        public int DailyLimit { get; }
        public int WeeklyProgress { get; }
        public int WeeklyLimit { get; }
        public int CurrentProgress { get; }
        public int Level { get; }
        public int LevelCap { get; }
        public int StepIndex { get; }
        public int ProgressToNextLevel { get; }
        public int NextLevelAt { get; }
        public int? CurrentResetCount { get; }
        public ReadOnlyCollection<DestinyProgressionReset> SeasonResets { get; }
        public ReadOnlyCollection<DestinyProgressionRewardItemState> RewardItemStates { get; }

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
