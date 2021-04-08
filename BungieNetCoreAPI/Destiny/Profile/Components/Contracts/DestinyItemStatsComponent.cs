using NetBungieAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemStatsComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat> Stats { get; init; }
        [JsonConstructor]
        internal DestinyItemStatsComponent(Dictionary<uint, DestinyStat> stats)
        {
            Stats = stats.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyStatDefinition, DestinyStat>(DefinitionsEnum.DestinyStatDefinition);
        }
    }
}
