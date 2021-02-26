using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class UninstancedItemObjective
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public double Progress { get; }
        public double CompletionValue { get; }
        public bool IsComplete { get; }
        public bool IsVisible { get; }

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
