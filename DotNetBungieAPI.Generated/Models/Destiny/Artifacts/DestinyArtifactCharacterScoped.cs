using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public sealed class DestinyArtifactCharacterScoped
{

    [JsonPropertyName("artifactHash")]
    public uint ArtifactHash { get; init; } // DestinyArtifactDefinition

    [JsonPropertyName("pointsUsed")]
    public int PointsUsed { get; init; }

    [JsonPropertyName("resetCount")]
    public int ResetCount { get; init; }

    [JsonPropertyName("tiers")]
    public List<Destiny.Artifacts.DestinyArtifactTier> Tiers { get; init; }
}
