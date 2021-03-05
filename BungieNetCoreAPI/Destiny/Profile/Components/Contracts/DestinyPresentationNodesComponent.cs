﻿using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPresentationNodesComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyPresentationNodeDefinition>, DestinyPresentationNodeComponent> Nodes { get; }

        [JsonConstructor]
        internal DestinyPresentationNodesComponent(Dictionary<uint, DestinyPresentationNodeComponent> nodes)
        {
            Nodes = nodes.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyPresentationNodeDefinition, DestinyPresentationNodeComponent>(DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}