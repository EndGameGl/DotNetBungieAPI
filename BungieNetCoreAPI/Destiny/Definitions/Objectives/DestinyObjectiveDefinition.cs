using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Objectives
{
    [DestinyDefinition("DestinyObjectiveDefinition")]
    public class DestinyObjectiveDefinition : DestinyDefinition
    {
        public bool AllowNegativeValue { get; }
        public bool AllowOvercompletion { get; }
        public bool AllowValueChangeWhenCompleted { get; }
        public ObjectiveUnlockValueUIStyle CompletedValueStyle { get; }
        public int CompletionValue { get; }
        public ObjectiveUnlockValueUIStyle InProgressValueStyle { get; }
        public bool IsCountingDownward { get; }
        public bool IsDisplayOnlyObjective { get; }
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }
        public int MinimumVisibilityThreshold { get; }
        public ObjectivePerks Perks { get; }
        public string ProgressDescription { get; }
        public Scope Scope { get; }
        public bool ShowValueOnComplete { get; }
        public ObjectiveStats Stats { get; }
        public ObjectiveUnlockValueUIStyle ValueStyle { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        private DestinyObjectiveDefinition(DestinyDefinitionDisplayProperties displayProperties, bool allowNegativeValue, bool allowOvercompletion, bool allowValueChangeWhenCompleted,
            ObjectiveUnlockValueUIStyle completedValueStyle, int completionValue, ObjectiveUnlockValueUIStyle inProgressValueStyle, bool isCountingDownward, bool isDisplayOnlyObjective, uint locationHash,
            int minimumVisibilityThreshold, ObjectivePerks perks, string progressDescription, Scope scope, bool showValueOnComplete, ObjectiveStats stats, ObjectiveUnlockValueUIStyle valueStyle,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            AllowNegativeValue = allowNegativeValue;
            AllowOvercompletion = allowOvercompletion;
            AllowValueChangeWhenCompleted = allowValueChangeWhenCompleted;
            CompletedValueStyle = completedValueStyle;
            CompletionValue = completionValue;
            InProgressValueStyle = inProgressValueStyle;
            IsCountingDownward = isCountingDownward;
            IsDisplayOnlyObjective = isDisplayOnlyObjective;
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, "DestinyLocationDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            MinimumVisibilityThreshold = minimumVisibilityThreshold;
            Perks = perks;
            ProgressDescription = progressDescription;
            Scope = scope;
            ShowValueOnComplete = showValueOnComplete;
            Stats = stats;
            ValueStyle = valueStyle;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
