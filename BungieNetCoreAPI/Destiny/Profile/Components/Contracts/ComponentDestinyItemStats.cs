using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemStats
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyStatDefinition>, DestinyStat> Stats { get; }
        [JsonConstructor]
        internal ComponentDestinyItemStats(Dictionary<uint, DestinyStat> stats)
        {
            Stats = stats.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyStatDefinition, DestinyStat>(DefinitionsEnum.DestinyStatDefinition);
        }
    }
}
