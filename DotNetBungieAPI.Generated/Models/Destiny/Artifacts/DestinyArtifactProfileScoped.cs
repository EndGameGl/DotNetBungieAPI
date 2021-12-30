using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public sealed class DestinyArtifactProfileScoped
{

    [JsonPropertyName("artifactHash")]
    public uint ArtifactHash { get; init; }

    [JsonPropertyName("pointProgression")]
    public Destiny.DestinyProgression PointProgression { get; init; }

    [JsonPropertyName("pointsAcquired")]
    public int PointsAcquired { get; init; }

    [JsonPropertyName("powerBonusProgression")]
    public Destiny.DestinyProgression PowerBonusProgression { get; init; }

    [JsonPropertyName("powerBonus")]
    public int PowerBonus { get; init; }
}
