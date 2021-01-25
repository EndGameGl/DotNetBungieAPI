using BungieNetCoreAPI.Destiny.Definitions.Collectibles;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodeCollectible
    {
        public DefinitionHashPointer<DestinyCollectibleDefinition> Collectible { get; }

        [JsonConstructor]
        private PresentationChildNodeCollectible(uint collectibleHash)
        {
            Collectible = new DefinitionHashPointer<DestinyCollectibleDefinition>(collectibleHash, DefinitionsEnum.DestinyCollectibleDefinition);
        }
    }
}
