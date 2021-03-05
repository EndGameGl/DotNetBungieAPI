using BungieNetCoreAPI.Destiny.Definitions.PlugSets;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPlugSetsComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyPlugSetDefinition>, object[]> Plugs { get; }

        [JsonConstructor]
        internal DestinyPlugSetsComponent(Dictionary<uint, object[]> plugs)
        {
            Plugs = plugs.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyPlugSetDefinition, object[]>(DefinitionsEnum.DestinyPlugSetDefinition);
        }
    }
}
