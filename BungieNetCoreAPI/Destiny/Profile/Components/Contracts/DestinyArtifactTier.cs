using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyArtifactTier
    {
        public uint TierHash { get; init; }
        public bool IsUnlocked { get; init; }
        public int PointsToUnlock { get; init; }
        public ReadOnlyCollection<DestinyArtifactTierItem> Items { get; init; }

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
