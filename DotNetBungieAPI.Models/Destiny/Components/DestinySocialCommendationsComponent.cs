using DotNetBungieAPI.Models.Destiny.Definitions.SocialCommendations;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinySocialCommendationsComponent
{
    [JsonPropertyName("totalScore")]
    public int TotalScore { get; init; }

    [JsonPropertyName("scoreDetailValues")]
    public ReadOnlyCollection<int> ScoreDetailValues { get; init; } =
        ReadOnlyCollection<int>.Empty;

    [JsonPropertyName("commendationNodeScoresByHash")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinySocialCommendationNodeDefinition>,
        int
    > CommendationNodeScoresByHash { get; init; } =
        ReadOnlyDictionary<
            DefinitionHashPointer<DestinySocialCommendationNodeDefinition>,
            int
        >.Empty;

    [JsonPropertyName("commendationScoresByHash")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinySocialCommendationDefinition>,
        int
    > CommendationScoresByHash { get; init; } =
        ReadOnlyDictionary<DefinitionHashPointer<DestinySocialCommendationDefinition>, int>.Empty;

    /// <summary>
    ///     The percentage for each commendation type out of total received
    /// </summary>
    [JsonPropertyName("commendationNodePercentagesByHash")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinySocialCommendationNodeDefinition>,
        uint
    > CommendationNodePercentagesByHash { get; set; } =
        ReadOnlyDictionary<
            DefinitionHashPointer<DestinySocialCommendationNodeDefinition>,
            uint
        >.Empty;
}
