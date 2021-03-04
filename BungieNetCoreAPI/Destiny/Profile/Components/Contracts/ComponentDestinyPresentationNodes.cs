using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyPresentationNodes
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyPresentationNodeDefinition>, DestinyPresentationNodeComponent> Nodes { get; }

        [JsonConstructor]
        internal ComponentDestinyPresentationNodes(Dictionary<uint, DestinyPresentationNodeComponent> nodes)
        {
            Nodes = nodes.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyPresentationNodeDefinition, DestinyPresentationNodeComponent>(DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
