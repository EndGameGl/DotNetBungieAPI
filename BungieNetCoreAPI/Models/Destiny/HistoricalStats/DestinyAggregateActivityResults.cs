using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyAggregateActivityResults
    {
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyAggregateActivityStats> Activities { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyAggregateActivityStats>();
    }
}
