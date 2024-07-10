using DotNetBungieAPI.Models.Destiny.HistoricalStats;

namespace DotNetBungieAPI.Models.Destiny.Responses;

public sealed record DestinyClanLeaderboardsResponseEntryValue
{
    [JsonPropertyName("basic")]
    public DestinyHistoricalStatsValuePair Basic { get; init; }
}
