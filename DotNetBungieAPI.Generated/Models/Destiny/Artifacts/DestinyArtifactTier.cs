namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactTier
{
    [JsonPropertyName("tierHash")]
    public uint? TierHash { get; set; }

    [JsonPropertyName("isUnlocked")]
    public bool? IsUnlocked { get; set; }

    [JsonPropertyName("pointsToUnlock")]
    public int? PointsToUnlock { get; set; }

    [JsonPropertyName("items")]
    public List<Destiny.Artifacts.DestinyArtifactTierItem> Items { get; set; }
}
