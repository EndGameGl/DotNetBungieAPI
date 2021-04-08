using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.Destinations;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    /// <summary>
    /// Returns data about a character's status with a given Objective. Combine with DestinyObjectiveDefinition static data for display purposes.
    /// </summary>
    public class DestinyObjectiveProgress
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        /// <summary>
        /// If progress has been made, and the progress can be measured numerically, this will be the value of that progress. You can compare it to the DestinyObjectiveDefinition.completionValue property for current vs. upper bounds, and use DestinyObjectiveDefinition.valueStyle to determine how this should be rendered. Note that progress, in Destiny 2, need not be a literal numeric progression. It could be one of a number of possible values, even a Timestamp. Always examine DestinyObjectiveDefinition.valueStyle before rendering progress.
        /// </summary>
        public int? Progress { get; init; }
        public int CompletionValue { get; init; }
        public bool IsComplete { get; init; }
        public bool IsVisible { get; init; }

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
