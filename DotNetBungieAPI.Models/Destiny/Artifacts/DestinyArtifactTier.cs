namespace DotNetBungieAPI.Models.Destiny.Artifacts;

public sealed class DestinyArtifactTier
{
    [JsonPropertyName("tierHash")]
    public uint TierHash { get; init; }

    [JsonPropertyName("isUnlocked")]
    public bool IsUnlocked { get; init; }

    [JsonPropertyName("pointsToUnlock")]
    public int PointsToUnlock { get; init; }

    [JsonPropertyName("items")]
    public Destiny.Artifacts.DestinyArtifactTierItem[]? Items { get; init; }
}
