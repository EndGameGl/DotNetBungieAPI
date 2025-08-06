namespace DotNetBungieAPI.Models.Destiny.Artifacts;

public sealed class DestinyArtifactCharacterScoped
{
    [JsonPropertyName("artifactHash")]
    public DefinitionHashPointer<Destiny.Definitions.Artifacts.DestinyArtifactDefinition> ArtifactHash { get; init; }

    [JsonPropertyName("pointsUsed")]
    public int PointsUsed { get; init; }

    [JsonPropertyName("resetCount")]
    public int ResetCount { get; init; }

    [JsonPropertyName("tiers")]
    public Destiny.Artifacts.DestinyArtifactTier[]? Tiers { get; init; }
}
