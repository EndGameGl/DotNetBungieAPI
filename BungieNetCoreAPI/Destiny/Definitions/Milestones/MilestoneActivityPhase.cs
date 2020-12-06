using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Milestones
{
    public class MilestoneActivityPhase
    {
        public uint PhaseCompleteUnlockHash { get; }
        public uint PhaseHash { get; }

        [JsonConstructor]
        private MilestoneActivityPhase(uint phaseCompleteUnlockHash, uint phaseHash)
        {
            PhaseCompleteUnlockHash = phaseCompleteUnlockHash;
            PhaseHash = phaseHash;
        }
    }
}
