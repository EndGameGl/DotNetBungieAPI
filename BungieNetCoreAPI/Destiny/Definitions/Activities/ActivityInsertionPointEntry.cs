using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityInsertionPointEntry
    {
        public uint PhaseHash { get; }
        public uint UnlockHash { get; }

        [JsonConstructor]
        private ActivityInsertionPointEntry(uint phaseHash, uint unlockHash)
        {
            PhaseHash = phaseHash;
            UnlockHash = unlockHash;
        }
    }
}
