using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactTier
    {
        public uint TierHash { get; }
        public bool IsUnlocked { get; }
        public int PointsToUnlock { get; }
        public ReadOnlyCollection<DestinyArtifactTierItem> Items { get; }

        [JsonConstructor]
        internal DestinyArtifactTier(uint tierHash, bool isUnlocked, int pointsToUnlock, DestinyArtifactTierItem[] items)
        {
            TierHash = tierHash;
            IsUnlocked = isUnlocked;
            PointsToUnlock = pointsToUnlock;
            Items = items.AsReadOnlyOrEmpty();
        }
    }
}
