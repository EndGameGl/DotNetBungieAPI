using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Artifacts
{
    public sealed record DestinyArtifactCharacterScoped
    {
        [JsonPropertyName("artifactHash")]
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; } = DefinitionHashPointer<DestinyArtifactDefinition>.Empty;
        [JsonPropertyName("pointsUsed")]
        public int PointsUsed { get; init; }
        [JsonPropertyName("resetCount")]
        public int ResetCount { get; init; }
        [JsonPropertyName("tiers")]
        public ReadOnlyCollection<DestinyArtifactTier> Tiers { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyArtifactTier>();
    }
}
