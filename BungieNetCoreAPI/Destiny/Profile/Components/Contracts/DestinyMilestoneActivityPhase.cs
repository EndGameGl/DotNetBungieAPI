using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivityPhase
    {
        public bool IsComplete { get; }
        public uint PhaseHash { get; }

        [JsonConstructor]
        internal DestinyMilestoneActivityPhase(bool complete, uint phaseHash)
        {
            IsComplete = complete;
            PhaseHash = phaseHash;
        }
    }
}
