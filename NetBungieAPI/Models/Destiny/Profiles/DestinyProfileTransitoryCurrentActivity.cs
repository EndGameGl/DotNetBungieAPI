using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Profiles
{
    /// <summary>
    /// If you are playing in an activity, this is some information about it.
    /// <para/>
    /// Note that we cannot guarantee any of this resembles what ends up in the PGCR in any way. They are sourced by two entirely separate systems with their own logic, and the one we source this data from should be considered non-authoritative in comparison.
    /// </summary>
    public sealed record DestinyProfileTransitoryCurrentActivity
    {
        /// <summary>
        /// When the activity started.
        /// </summary>
        [JsonPropertyName("startTime")]
        public DateTime? StartTime { get; init; }

        /// <summary>
        /// If you're still in it but it "ended" (like when folks are dancing around the loot after they beat a boss), this is when the activity ended.
        /// </summary>
        [JsonPropertyName("endTime")]
        public DateTime? EndTime { get; init; }

        /// <summary>
        /// This is what our non-authoritative source thought the score was.
        /// </summary>
        [JsonPropertyName("score")]
        public float Score { get; init; }

        /// <summary>
        /// If you have human opponents, this is the highest opposing team's score.
        /// </summary>
        [JsonPropertyName("highestOpposingFactionScore")]
        public float HighestOpposingFactionScore { get; init; }

        /// <summary>
        /// This is how many human or poorly crafted aimbot opponents you have.
        /// </summary>
        [JsonPropertyName("numberOfOpponents")]
        public int NumberOfOpponents { get; init; }

        /// <summary>
        /// This is how many human or poorly crafted aimbots are on your team.
        /// </summary>
        [JsonPropertyName("numberOfPlayers")]
        public int NumberOfPlayers { get; init; }
    }
}