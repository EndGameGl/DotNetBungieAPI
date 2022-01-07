using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneChallengeDefinition
{

    /// <summary>
    ///     The challenge related to this milestone.
    /// </summary>
    [JsonPropertyName("challengeObjectiveHash")]
    public uint ChallengeObjectiveHash { get; init; } // DestinyObjectiveDefinition
}
