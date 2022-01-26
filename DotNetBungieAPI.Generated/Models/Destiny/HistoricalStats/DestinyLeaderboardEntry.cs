namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyLeaderboardEntry : IDeepEquatable<DestinyLeaderboardEntry>
{
    /// <summary>
    ///     Where this player ranks on the leaderboard. A value of 1 is the top rank.
    /// </summary>
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    /// <summary>
    ///     Identity details of the player
    /// </summary>
    [JsonPropertyName("player")]
    public Destiny.HistoricalStats.DestinyPlayer Player { get; set; }

    /// <summary>
    ///     ID of the player's best character for the reported stat.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    /// <summary>
    ///     Value of the stat for this player
    /// </summary>
    [JsonPropertyName("value")]
    public Destiny.HistoricalStats.DestinyHistoricalStatsValue Value { get; set; }

    public bool DeepEquals(DestinyLeaderboardEntry? other)
    {
        return other is not null &&
               Rank == other.Rank &&
               (Player is not null ? Player.DeepEquals(other.Player) : other.Player is null) &&
               CharacterId == other.CharacterId &&
               (Value is not null ? Value.DeepEquals(other.Value) : other.Value is null);
    }
}