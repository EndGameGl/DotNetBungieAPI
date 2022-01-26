namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeDefinition : IDeepEquatable<DestinyMilestoneChallengeDefinition>
{
    /// <summary>
    ///     The challenge related to this milestone.
    /// </summary>
    [JsonPropertyName("challengeObjectiveHash")]
    public uint ChallengeObjectiveHash { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeDefinition? other)
    {
        return other is not null &&
               ChallengeObjectiveHash == other.ChallengeObjectiveHash;
    }
}