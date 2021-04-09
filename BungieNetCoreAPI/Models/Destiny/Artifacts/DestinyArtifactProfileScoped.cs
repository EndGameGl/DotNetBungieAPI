using NetBungieAPI.Models.Destiny.Definitions.Artifacts;
using NetBungieAPI.Models.Destiny.Progressions;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Artifacts
{
    public sealed record DestinyArtifactProfileScoped
    {
        [JsonPropertyName("artifactHash")]
        public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; } = DefinitionHashPointer<DestinyArtifactDefinition>.Empty;
        [JsonPropertyName("pointProgression")]
        public DestinyProgression PointProgression { get; init; }
        [JsonPropertyName("pointsAcquired")]
        public int PointsAcquired { get; init; }
        [JsonPropertyName("powerBonusProgression")]
        public DestinyProgression PowerBonusProgression { get; init; }
        [JsonPropertyName("powerBonus")]
        public int PowerBonus { get; init; }
    }
}
