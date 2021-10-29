using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyPostGameCarnageReportEntry
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
        public DestinyHistoricalStatsValue Score { get; init; }

        /// <summary>
        ///     Identity details of the player
        /// </summary>
        [JsonPropertyName("player")]
        public DestinyPlayer Player { get; init; }

        /// <summary>
        ///     ID of the player's character used in the activity.
        /// </summary>
        [JsonPropertyName("characterId")]
        public long CharacterId { get; init; }

        /// <summary>
        ///     Collection of stats for the player in this activity.
        /// </summary>
        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            ReadOnlyDictionaries<string, DestinyHistoricalStatsValue>.Empty;

        /// <summary>
        ///     Extended data extracted from the activity blob.
        /// </summary>
        [JsonPropertyName("extended")]
        public DestinyPostGameCarnageReportExtendedData ExtendedData { get; init; }
    }
}