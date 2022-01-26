namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeActivityPhase : IDeepEquatable<DestinyMilestoneChallengeActivityPhase>
{
    /// <summary>
    ///     The hash identifier of the activity's phase.
    /// </summary>
    [JsonPropertyName("phaseHash")]
    public uint PhaseHash { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeActivityPhase? other)
    {
        return other is not null &&
               PhaseHash == other.PhaseHash;
    }
}