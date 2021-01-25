using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Objectives
{
    [DestinyDefinition(name: "DestinyObjectiveDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyObjectiveDefinition : IDestinyDefinition
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
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyObjectiveDefinition(DestinyDefinitionDisplayProperties displayProperties, bool allowNegativeValue, bool allowOvercompletion, bool allowValueChangeWhenCompleted,
            ObjectiveUnlockValueUIStyle completedValueStyle, int completionValue, ObjectiveUnlockValueUIStyle inProgressValueStyle, bool isCountingDownward, bool isDisplayOnlyObjective, uint locationHash,
            int minimumVisibilityThreshold, ObjectivePerks perks, string progressDescription, Scope scope, bool showValueOnComplete, ObjectiveStats stats, ObjectiveUnlockValueUIStyle valueStyle,
            bool blacklisted, uint hash, int index, bool redacted)
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
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, DefinitionsEnum.DestinyLocationDefinition);
            MinimumVisibilityThreshold = minimumVisibilityThreshold;
            Perks = perks;
            ProgressDescription = progressDescription;
            Scope = scope;
            ShowValueOnComplete = showValueOnComplete;
            Stats = stats;
            ValueStyle = valueStyle;
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
