using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public sealed class DestinyPostGameCarnageReportEntry
{

    /// <summary>
    ///     Standing of the player
    /// </summary>
    [JsonPropertyName("standing")]
    public int Standing { get; init; }

    /// <summary>
    ///     Score of the player if available
    /// </summary>
    [JsonPropertyName("score")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Score { get; init; }

    /// <summary>
    ///     Identity details of the player
    /// </summary>
    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; init; }

    /// <summary>
    ///     ID of the player's character used in the activity.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; init; }

    /// <summary>
    ///     Extended data extracted from the activity blob.
    /// </summary>
    [JsonPropertyName("extended")]
    public Destiny.HistoricalStats.DestinyPostGameCarnageReportExtendedData Extended { get; init; }
}
