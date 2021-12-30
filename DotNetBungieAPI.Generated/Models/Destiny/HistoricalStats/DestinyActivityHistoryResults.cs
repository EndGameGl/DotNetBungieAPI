using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyActivityHistoryResults
{

    [JsonPropertyName("activities")]
    public List<Destiny.HistoricalStats.DestinyHistoricalStatsPeriodGroup> Activities { get; init; }
}
