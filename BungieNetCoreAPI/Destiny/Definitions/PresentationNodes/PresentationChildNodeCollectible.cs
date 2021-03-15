using NetBungieAPI.Destiny.Definitions.Collectibles;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationChildNodeCollectible : IDeepEquatable<PresentationChildNodeCollectible>
    {
        public DefinitionHashPointer<DestinyCollectibleDefinition> Collectible { get; }

        [JsonConstructor]
        internal PresentationChildNodeCollectible(uint collectibleHash)
        {
            Collectible = new DefinitionHashPointer<DestinyCollectibleDefinition>(collectibleHash, DefinitionsEnum.DestinyCollectibleDefinition);
        }

        public bool DeepEquals(PresentationChildNodeCollectible other)
        {
            return other != null && Collectible.DeepEquals(other.Collectible);
        }
    }
}
