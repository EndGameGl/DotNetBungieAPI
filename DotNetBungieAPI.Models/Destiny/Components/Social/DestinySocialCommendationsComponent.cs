namespace DotNetBungieAPI.Models.Destiny.Components.Social;

public sealed class DestinySocialCommendationsComponent
{
    [JsonPropertyName("totalScore")]
    public int TotalScore { get; init; }

    /// <summary>
    ///     The percentage for each commendation type out of total received
    /// </summary>
    [JsonPropertyName("commendationNodePercentagesByHash")]
    public Dictionary<uint, uint>? CommendationNodePercentagesByHash { get; init; }

    [JsonPropertyName("scoreDetailValues")]
    public int[]? ScoreDetailValues { get; init; }

    [JsonPropertyName("commendationNodeScoresByHash")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition>, int>? CommendationNodeScoresByHash { get; init; }

    [JsonPropertyName("commendationScoresByHash")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.Social.DestinySocialCommendationDefinition>, int>? CommendationScoresByHash { get; init; }
}
