using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Artifacts
{
    public sealed record DestinyArtifactTierDefinition : IDeepEquatable<DestinyArtifactTierDefinition>
    {
        /// <summary>
        ///     The human readable title of this tier, if any.
        /// </summary>
        [JsonPropertyName("displayTitle")]
        public string DisplayTitle { get; init; }

        /// <summary>
        ///     The items that can be earned within this tier.
        /// </summary>
        [JsonPropertyName("items")]
        public ReadOnlyCollection<DestinyArtifactTierItemDefinition> Items { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyArtifactTierItemDefinition>();

        /// <summary>
        ///     The minimum number of "unlock points" that you must have used before you can unlock items from this tier.
        /// </summary>
        [JsonPropertyName("minimumUnlockPointsUsedRequirement")]
        public int MinimumUnlockPointsUsedRequirement { get; init; }

        /// <summary>
        ///     An identifier, unique within the Artifact, for this specific tier.
        /// </summary>
        [JsonPropertyName("tierHash")]
        public uint TierHash { get; init; }

        /// <summary>
        ///     A string representing the localized minimum requirement text for this Tier, if any.
        /// </summary>
        [JsonPropertyName("progressRequirementMessage")]
        public string ProgressRequirementMessage { get; init; }

        public bool DeepEquals(DestinyArtifactTierDefinition other)
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