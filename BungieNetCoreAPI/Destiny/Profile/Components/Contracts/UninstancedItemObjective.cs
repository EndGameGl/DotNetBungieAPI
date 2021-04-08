using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class UninstancedItemObjective
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; }
        public double Progress { get; init; }
        public double CompletionValue { get; init; }
        public bool IsComplete { get; init; }
        public bool IsVisible { get; init; }

        [JsonConstructor]
        internal UninstancedItemObjective(uint objectiveHash, double progress, double completionValue, bool complete, bool visible)
        {
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            Progress = progress;
            CompletionValue = completionValue;
            IsComplete = complete;
            IsVisible = visible;
        }
    }
}
