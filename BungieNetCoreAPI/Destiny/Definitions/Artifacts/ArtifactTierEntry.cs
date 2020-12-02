using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Artifacts
{
    public class ArtifactTierEntry
    {
        public string DisplayTitle { get; }
        public List<ArtifactTierEntryItemEntry> Items { get; }
        public int MinimumUnlockPointsUsedRequirement { get; }
        public uint TierHash { get; }

        [JsonConstructor]
        private ArtifactTierEntry(string displayTitle, List<ArtifactTierEntryItemEntry> items, int minimumUnlockPointsUsedRequirement, uint tierHash)
        {
            DisplayTitle = displayTitle;
            if (items == null)
                Items = new List<ArtifactTierEntryItemEntry>();
            else
                Items = items;
            MinimumUnlockPointsUsedRequirement = minimumUnlockPointsUsedRequirement;
            TierHash = tierHash;
        }
    }
}
