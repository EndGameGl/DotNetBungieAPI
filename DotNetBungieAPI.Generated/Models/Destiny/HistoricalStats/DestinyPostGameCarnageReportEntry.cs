namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyPostGameCarnageReportEntry
{
    /// <summary>
    ///     Standing of the player
    /// </summary>
    [JsonPropertyName("standing")]
    public int Standing { get; set; }

    /// <summary>
    ///     Score of the player if available
    /// </summary>
    [JsonPropertyName("score")]
    public object Score { get; set; }

    /// <summary>
    ///     Identity details of the player
    /// </summary>
    [JsonPropertyName("player")]
    public object Player { get; set; }

    /// <summary>
    ///     ID of the player's character used in the activity.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>
    ///     Collection of stats for the player in this activity.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.HistoricalStats.DestinyHistoricalStatsValue> Values { get; set; }

    /// <summary>
    ///     Extended data extracted from the activity blob.
    /// </summary>
    [JsonPropertyName("extended")]
    public object Extended { get; set; }
}
