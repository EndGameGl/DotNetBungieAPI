namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Social;

public class DestinySocialCommendationsComponent
{
    [JsonPropertyName("totalScore")]
    public int? TotalScore { get; set; }

    /// <summary>
    ///     The percentage for each commendation type out of total received
    /// </summary>
    [JsonPropertyName("commendationNodePercentagesByHash")]
    public Dictionary<uint, uint> CommendationNodePercentagesByHash { get; set; }

    [JsonPropertyName("scoreDetailValues")]
    public List<int> ScoreDetailValues { get; set; }

    [JsonPropertyName("commendationNodeScoresByHash")]
    public Dictionary<uint, int> CommendationNodeScoresByHash { get; set; }

    [JsonPropertyName("commendationScoresByHash")]
    public Dictionary<uint, int> CommendationScoresByHash { get; set; }
}
