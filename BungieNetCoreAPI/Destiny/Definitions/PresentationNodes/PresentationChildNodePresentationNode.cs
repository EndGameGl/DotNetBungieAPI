﻿using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodePresentationNode : IDeepEquatable<PresentationChildNodePresentationNode>
    {
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> PresentationNode { get; }

        [JsonConstructor]
        internal PresentationChildNodePresentationNode(uint presentationNodeHash)
        {
            PresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(presentationNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }

        public bool DeepEquals(PresentationChildNodePresentationNode other)
        {
            return other != null && PresentationNode.DeepEquals(other.PresentationNode);
        }
    }
}
