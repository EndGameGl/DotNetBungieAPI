using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Progressions
{
    /// <summary>
    ///     Represents a season and the number of resets you had in that season.
    ///     <para />
    ///     We do not necessarily - even for progressions with resets - track it over all seasons. So be careful and check the
    ///     season numbers being returned.
    /// </summary>
    public sealed record DestinyProgressionResetEntry
    {
        /// <summary>
        ///     Number of season
        /// </summary>
        [JsonPropertyName("season")]
        public int Season { get; init; }

        /// <summary>
        ///     Amount of resets
        /// </summary>
        [JsonPropertyName("resets")]
        public int Resets { get; init; }
    }
}