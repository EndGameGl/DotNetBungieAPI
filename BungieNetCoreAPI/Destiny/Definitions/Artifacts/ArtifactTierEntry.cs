using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Artifacts
{
    public class ArtifactTierEntry : IDeepEquatable<ArtifactTierEntry>
    {
        /// <summary>
        /// The human readable title of this tier, if any.
        /// </summary>
        public string DisplayTitle { get; }
        /// <summary>
        /// The items that can be earned within this tier.
        /// </summary>
        public ReadOnlyCollection<ArtifactTierEntryItemEntry> Items { get; }
        /// <summary>
        /// The minimum number of "unlock points" that you must have used before you can unlock items from this tier.
        /// </summary>
        public int MinimumUnlockPointsUsedRequirement { get; }
        /// <summary>
        /// An identifier, unique within the Artifact, for this specific tier.
        /// </summary>
        public uint TierHash { get; }
        /// <summary>
        /// A string representing the localized minimum requirement text for this Tier, if any.
        /// </summary>
        public string ProgressRequirementMessage { get; }

        [JsonConstructor]
        internal ArtifactTierEntry(string displayTitle, ArtifactTierEntryItemEntry[] items, int minimumUnlockPointsUsedRequirement, uint tierHash,
            string progressRequirementMessage)
        {
            DisplayTitle = displayTitle;
            Items = items.AsReadOnlyOrEmpty();
            MinimumUnlockPointsUsedRequirement = minimumUnlockPointsUsedRequirement;
            TierHash = tierHash;
            ProgressRequirementMessage = progressRequirementMessage;
        }

        public bool DeepEquals(ArtifactTierEntry other)
        {
            return other != null &&
                   DisplayTitle == other.DisplayTitle &&
                   Items.DeepEqualsReadOnlyCollections(other.Items) &&
                   MinimumUnlockPointsUsedRequirement == other.MinimumUnlockPointsUsedRequirement &&
                   TierHash == other.TierHash &&
                   ProgressRequirementMessage == other.ProgressRequirementMessage;
        }
    }
}
