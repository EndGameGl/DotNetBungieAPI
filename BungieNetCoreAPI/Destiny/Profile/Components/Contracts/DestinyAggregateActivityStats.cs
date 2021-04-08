using NetBungieAPI.Models.Destiny.Definitions.Activities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyAggregateActivityStats
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; }

        [JsonConstructor]
        internal DestinyAggregateActivityStats(uint activityHash, Dictionary<string, DestinyHistoricalStatsValue> values)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Values = values.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
