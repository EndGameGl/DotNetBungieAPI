using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyAggregateActivityResults
    {
        /// <summary>
        /// List of all activities the player has participated in.
        /// </summary>
        [JsonPropertyName("activities")]
        public ReadOnlyCollection<DestinyAggregateActivityStats> Activities { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyAggregateActivityStats>();
    }
}