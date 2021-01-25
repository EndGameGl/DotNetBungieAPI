using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivities
    {
        public List<MilestoneActivityGraphNode> ActivityGraphNodes { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public List<MilestoneActivityChallenge> Challenges { get; }
        public List<MilestoneActivityPhase> Phases { get; }

        [JsonConstructor]
        private MilestoneActivities(List<MilestoneActivityGraphNode> activityGraphNodes, uint activityHash, List<MilestoneActivityChallenge> challenges,
            List<MilestoneActivityPhase> phases)
        {
            ActivityGraphNodes = activityGraphNodes;
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Challenges = challenges;
            Phases = phases;
        }
    }
}
