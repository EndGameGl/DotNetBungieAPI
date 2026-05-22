namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

public sealed class DestinySeasonalHubRankIconImages
{
    [JsonPropertyName("seasonalHubRankIconUnearned")]
    public string SeasonalHubRankIconUnearned { get; init; }

    [JsonPropertyName("seasonalHubRankIconEarning")]
    public string SeasonalHubRankIconEarning { get; init; }

    [JsonPropertyName("seasonalHubRankIconActive")]
    public string SeasonalHubRankIconActive { get; init; }
}
