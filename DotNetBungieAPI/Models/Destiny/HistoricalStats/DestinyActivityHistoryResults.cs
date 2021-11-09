namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyActivityHistoryResults
    {
        /// <summary>
        ///     List of activities, the most recent activity first.
        /// </summary>
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Activities { get; init; } =
            ReadOnlyCollections<DestinyHistoricalStatsPeriodGroup>.Empty;
    }
}