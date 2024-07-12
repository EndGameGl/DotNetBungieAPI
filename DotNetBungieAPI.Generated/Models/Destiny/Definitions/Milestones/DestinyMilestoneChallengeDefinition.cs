namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeDefinition
{
    /// <summary>
    ///     The challenge related to this milestone.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("challengeObjectiveHash")]
    public uint? ChallengeObjectiveHash { get; set; }
}
