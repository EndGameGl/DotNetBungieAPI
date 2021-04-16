using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyActivityHistoryResults
    {
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Activities { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyHistoricalStatsPeriodGroup>();
    }
}
