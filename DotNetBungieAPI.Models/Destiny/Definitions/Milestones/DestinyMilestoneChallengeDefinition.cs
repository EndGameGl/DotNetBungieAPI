using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

public sealed record DestinyMilestoneChallengeDefinition
    : IDeepEquatable<DestinyMilestoneChallengeDefinition>
{
    /// <summary>
    ///     The challenge related to this milestone.
    /// </summary>
    [JsonPropertyName("challengeObjectiveHash")]
    public DefinitionHashPointer<DestinyObjectiveDefinition> ChallengeObjective { get; init; } =
        DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

    public bool DeepEquals(DestinyMilestoneChallengeDefinition other)
    {
        return other != null && ChallengeObjective.DeepEquals(other.ChallengeObjective);
    }
}
