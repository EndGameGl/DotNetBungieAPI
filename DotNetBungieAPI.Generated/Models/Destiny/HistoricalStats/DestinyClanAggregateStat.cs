using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyClanAggregateStat
{

    /// <summary>
    ///     The id of the mode of stats (allPvp, allPvE, etc)
    /// </summary>
    [JsonPropertyName("mode")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType Mode { get; init; }

    /// <summary>
    ///     The id of the stat
    /// </summary>
    [JsonPropertyName("statId")]
    public string StatId { get; init; }

    /// <summary>
    ///     Value of the stat for this player
    /// </summary>
    [JsonPropertyName("value")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Value { get; init; }
}
