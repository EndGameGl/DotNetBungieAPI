namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

/// <summary>
///     Represents a Seasonal Artifact and all data related to it for the requested Account.
/// <para />
///     It can be combined with Character-scoped data for a full picture of what a character has available/has chosen, or just these settings can be used for overview information.
/// </summary>
public class DestinyArtifactProfileScoped
{
    [Destiny2Definition<Destiny.Definitions.Artifacts.DestinyArtifactDefinition>("Destiny.Definitions.Artifacts.DestinyArtifactDefinition")]
    [JsonPropertyName("artifactHash")]
    public uint? ArtifactHash { get; set; }

    [JsonPropertyName("pointProgression")]
    public Destiny.DestinyProgression? PointProgression { get; set; }

    [JsonPropertyName("pointsAcquired")]
    public int? PointsAcquired { get; set; }

    [JsonPropertyName("powerBonusProgression")]
    public Destiny.DestinyProgression? PowerBonusProgression { get; set; }

    [JsonPropertyName("powerBonus")]
    public int? PowerBonus { get; set; }
}
