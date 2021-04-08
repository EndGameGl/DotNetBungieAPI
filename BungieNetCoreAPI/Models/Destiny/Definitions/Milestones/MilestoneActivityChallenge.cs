using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityChallenge : IDeepEquatable<MilestoneActivityChallenge>
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> ChallengeObjective { get; init; }

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
