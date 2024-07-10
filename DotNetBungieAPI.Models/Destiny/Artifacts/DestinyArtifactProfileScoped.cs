using DotNetBungieAPI.Models.Destiny.Definitions.Artifacts;
using DotNetBungieAPI.Models.Destiny.Progressions;

namespace DotNetBungieAPI.Models.Destiny.Artifacts;

/// <summary>
///     Represents a Seasonal Artifact and all data related to it for the requested Account.
///     <para />
///     It can be combined with Character-scoped data for a full picture of what a character has available/has chosen, or
///     just these settings can be used for overview information.
/// </summary>
public sealed record DestinyArtifactProfileScoped
{
    [JsonPropertyName("artifactHash")]
    public DefinitionHashPointer<DestinyArtifactDefinition> Artifact { get; init; } =
        DefinitionHashPointer<DestinyArtifactDefinition>.Empty;

    [JsonPropertyName("pointProgression")]
    public DestinyProgression PointProgression { get; init; }

    [JsonPropertyName("pointsAcquired")]
    public int PointsAcquired { get; init; }

    [JsonPropertyName("powerBonusProgression")]
    public DestinyProgression PowerBonusProgression { get; init; }

    [JsonPropertyName("powerBonus")]
    public int PowerBonus { get; init; }
}
