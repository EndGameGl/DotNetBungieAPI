using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    public sealed record DestinyMilestoneChallengeActivityPhase : IDeepEquatable<DestinyMilestoneChallengeActivityPhase>
    {
        [JsonPropertyName("phaseCompleteUnlockHash")]
        public uint PhaseCompleteUnlockHash { get; init; }

        [JsonPropertyName("phaseHash")]
        public uint PhaseHash { get; init; }

        public bool DeepEquals(DestinyMilestoneChallengeActivityPhase other)
        {
            return other != null && PhaseCompleteUnlockHash == other.PhaseCompleteUnlockHash && PhaseHash == other.PhaseHash;
        }
    }
}
