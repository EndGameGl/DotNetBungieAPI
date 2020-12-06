using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodePresentationNode
    {
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> PresentationNode { get; }

        [JsonConstructor]
        private PresentationChildNodePresentationNode(uint presentationNodeHash)
        {
            PresentationNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(presentationNodeHash, "DestinyPresentationNodeDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
