using DotNetBungieAPI.Models.Destiny.Definitions.Artifacts;

namespace DotNetBungieAPI.Models.Destiny.Artifacts;

public sealed record DestinyArtifactCharacterScoped
{
    [JsonPropertyName("artifactHash")]
    public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; } =
        DefinitionHashPointer<DestinyArtifactDefinition>.Empty;

    [JsonPropertyName("pointsUsed")] public int PointsUsed { get; init; }
    [JsonPropertyName("resetCount")] public int ResetCount { get; init; }

    [JsonPropertyName("tiers")]
    public ReadOnlyCollection<DestinyArtifactTier> Tiers { get; init; } =
        ReadOnlyCollections<DestinyArtifactTier>.Empty;
}