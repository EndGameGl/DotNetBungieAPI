using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Activities;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyAggregateActivityStats
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
    }
}
