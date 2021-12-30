using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

/// <summary>
///     Represents a Seasonal Artifact and all data related to it for the requested Account.
/// <para />
///     It can be combined with Character-scoped data for a full picture of what a character has available/has chosen, or just these settings can be used for overview information.
/// </summary>
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
