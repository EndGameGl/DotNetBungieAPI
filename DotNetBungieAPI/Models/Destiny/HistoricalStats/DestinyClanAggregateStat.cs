using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModes;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyClanAggregateStat
    {
        /// <summary>
        ///     The id of the mode of stats (allPvp, allPvE, etc)
        /// </summary>
        [JsonPropertyName("mode")]
        public DestinyActivityModeType Mode { get; init; }

        /// <summary>
        ///     The id of the stat
        /// </summary>
        [JsonPropertyName("statId")]
        public HistoricalStatDefinitionPointer Stat { get; init; }

        /// <summary>
        ///     Value of the stat for this player
        /// </summary>
        [JsonPropertyName("value")]
        public DestinyHistoricalStatsValue Value { get; init; }
    }
}