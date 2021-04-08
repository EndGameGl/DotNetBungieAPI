using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityPhase : IDeepEquatable<MilestoneActivityPhase>
    {
        public uint PhaseCompleteUnlockHash { get; init; }
        public uint PhaseHash { get; init; }

        [JsonConstructor]
        internal MilestoneActivityPhase(uint phaseCompleteUnlockHash, uint phaseHash)
        {
            PhaseCompleteUnlockHash = phaseCompleteUnlockHash;
            PhaseHash = phaseHash;
        }

        public bool DeepEquals(MilestoneActivityPhase other)
        {
            return other != null && PhaseCompleteUnlockHash == other.PhaseCompleteUnlockHash && PhaseHash == other.PhaseHash;
        }
    }
}
