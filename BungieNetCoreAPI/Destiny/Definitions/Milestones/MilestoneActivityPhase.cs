using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityPhase : IDeepEquatable<MilestoneActivityPhase>
    {
        public uint PhaseCompleteUnlockHash { get; }
        public uint PhaseHash { get; }

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
