using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// A point of entry into an activity, gated by an unlock flag and with some more-or-less useless (for our purposes) phase information..
    /// </summary>
    public class ActivityInsertionPointEntry : IDeepEquatable<ActivityInsertionPointEntry>
    {
        /// <summary>
        /// A unique hash value representing the phase. This can be useful for, for example, comparing how different instances of Raids have phases in different orders!
        /// </summary>
        public uint PhaseHash { get; }
        public uint UnlockHash { get; }

        [JsonConstructor]
        internal ActivityInsertionPointEntry(uint phaseHash, uint unlockHash)
        {
            PhaseHash = phaseHash;
            UnlockHash = unlockHash;
        }

        public bool DeepEquals(ActivityInsertionPointEntry other)
        {
            return other != null && 
                PhaseHash == other.PhaseHash &&
                UnlockHash == other.UnlockHash;
        }
    }
}
