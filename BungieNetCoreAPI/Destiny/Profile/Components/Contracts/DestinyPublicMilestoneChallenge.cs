using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneChallenge
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }

        [JsonConstructor]
        internal DestinyPublicMilestoneChallenge(uint objectiveHash, uint? activityHash)
        {
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
        }
    }
}
