using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityChallenge : IDeepEquatable<MilestoneActivityChallenge>
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> ChallengeObjective { get; }

        [JsonConstructor]
        internal MilestoneActivityChallenge(uint challengeObjectiveHash)
        {
            ChallengeObjective = new DefinitionHashPointer<DestinyObjectiveDefinition>(challengeObjectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
        }

        public bool DeepEquals(MilestoneActivityChallenge other)
        {
            return other != null && ChallengeObjective.DeepEquals(other.ChallengeObjective);
        }
    }
}
