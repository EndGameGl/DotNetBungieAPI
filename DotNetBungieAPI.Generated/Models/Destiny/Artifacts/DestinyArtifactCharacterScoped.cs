namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactCharacterScoped : IDeepEquatable<DestinyArtifactCharacterScoped>
{
    [JsonPropertyName("artifactHash")]
    public uint ArtifactHash { get; set; }

    [JsonPropertyName("pointsUsed")]
    public int PointsUsed { get; set; }

    [JsonPropertyName("resetCount")]
    public int ResetCount { get; set; }

    [JsonPropertyName("tiers")]
    public List<Destiny.Artifacts.DestinyArtifactTier> Tiers { get; set; }

    public bool DeepEquals(DestinyArtifactCharacterScoped? other)
    {
        return other is not null &&
               ArtifactHash == other.ArtifactHash &&
               PointsUsed == other.PointsUsed &&
               ResetCount == other.ResetCount &&
               Tiers.DeepEqualsList(other.Tiers);
    }
}