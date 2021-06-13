using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneChallengeDefinition : IDeepEquatable<DestinyMilestoneChallengeDefinition>
    {
        /// <summary>
        /// The challenge related to this milestone.
        /// </summary>
        [JsonPropertyName("challengeObjectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> ChallengeObjective { get; init; } =
            DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

        public bool DeepEquals(DestinyMilestoneChallengeDefinition other)
        {
            return other != null && ChallengeObjective.DeepEquals(other.ChallengeObjective);
        }
    }
}