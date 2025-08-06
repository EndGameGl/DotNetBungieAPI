namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneChallengeDefinition
{
    /// <summary>
    ///     The challenge related to this milestone.
    /// </summary>
    [JsonPropertyName("challengeObjectiveHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyObjectiveDefinition> ChallengeObjectiveHash { get; init; }
}
