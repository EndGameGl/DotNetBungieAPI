using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyObjectiveProgress
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public int? Progress { get; }
        public int CompletionValue { get; }
        public bool IsComplete { get; }
        public bool IsVisible { get; }

        [JsonConstructor]
        internal DestinyObjectiveProgress(uint objectiveHash, uint? destinationHash, uint? activityHash, int? progress, int completionValue,
            bool complete, bool visible)
        {
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Progress = progress;
            CompletionValue = completionValue;
            IsComplete = complete;
            IsVisible = visible;
        }
    }
}
