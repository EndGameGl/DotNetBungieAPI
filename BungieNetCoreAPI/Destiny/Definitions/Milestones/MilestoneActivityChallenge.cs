using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityChallenge
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> ChallengeObjective { get; }

        [JsonConstructor]
        private MilestoneActivityChallenge(uint challengeObjectiveHash)
        {
            ChallengeObjective = new DefinitionHashPointer<DestinyObjectiveDefinition>(challengeObjectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
        }
    }
}
