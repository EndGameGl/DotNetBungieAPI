using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Artifacts
{
    public sealed record DestinyArtifactTier
    {
        [JsonPropertyName("tierHash")] public uint TierHash { get; init; }
        [JsonPropertyName("isUnlocked")] public bool IsUnlocked { get; init; }
        [JsonPropertyName("pointsToUnlock")] public int PointsToUnlock { get; init; }

        [JsonPropertyName("items")]
        public ReadOnlyCollection<DestinyArtifactTierItem> Items { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyArtifactTierItem>();
    }
}