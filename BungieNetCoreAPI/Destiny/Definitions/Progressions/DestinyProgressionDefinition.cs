using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Progressions
{
    [DestinyDefinition(name: "DestinyProgressionDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyProgressionDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyColor Color { get; }
        public int ProgressToNextStepScaling { get; }
        public string RankIcon { get; }
        public bool RepeatLastStep { get; }
        public List<ProgressionReward> RewardItems { get; }
        public Scope Scope { get; }
        public int StorageMappingIndex { get; }
        public bool Visible { get; }
        public List<ProgressionStep> Steps { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyProgressionDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyColor color, int progressToNextStepScaling, string rankIcon,
            bool repeatLastStep, List<ProgressionReward> rewardItems, Scope scope, int storageMappingIndex, bool visible, List<ProgressionStep> steps,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Color = color;
            ProgressToNextStepScaling = progressToNextStepScaling;
            RankIcon = rankIcon;
            RepeatLastStep = repeatLastStep;
            RewardItems = rewardItems;
            Scope = scope;
            StorageMappingIndex = storageMappingIndex;
            Visible = visible;
            Steps = steps;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
