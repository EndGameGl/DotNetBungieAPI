﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyActivityHistoryResults
    {
        /// <summary>
        ///     List of activities, the most recent activity first.
        /// </summary>
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Activities { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalStatsPeriodGroup>();
    }
}