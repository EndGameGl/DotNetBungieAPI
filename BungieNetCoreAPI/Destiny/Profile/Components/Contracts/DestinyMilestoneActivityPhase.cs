using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneActivityPhase
    {
        public bool IsComplete { get; init; }
        public uint PhaseHash { get; init; }

        [JsonConstructor]
        internal DestinyMilestoneActivityPhase(bool complete, uint phaseHash)
        {
            IsComplete = complete;
            PhaseHash = phaseHash;
        }
    }
}
