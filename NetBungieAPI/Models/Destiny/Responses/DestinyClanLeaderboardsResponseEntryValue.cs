using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.HistoricalStats;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyClanLeaderboardsResponseEntryValue
    {
        [JsonPropertyName("basic")]
        public DestinyHistoricalStatsValuePair Basic { get; init; }
    }
}