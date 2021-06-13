using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Activities;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyAggregateActivityStats
    {
        /// <summary>
        /// Hash ID that can be looked up in the DestinyActivityTable.
        /// </summary>
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        /// <summary>
        /// Collection of stats for the player in this activity.
        /// </summary>
        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
    }
}