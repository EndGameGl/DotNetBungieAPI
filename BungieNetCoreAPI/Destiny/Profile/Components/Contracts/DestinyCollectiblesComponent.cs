using NetBungieApi.Destiny.Definitions.Collectibles;
using NetBungieApi.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyCollectiblesComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent> Collectibles { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; }

        [JsonConstructor]
        internal DestinyCollectiblesComponent(Dictionary<uint, DestinyCollectibleComponent> collectibles, uint collectionCategoriesRootNodeHash,
            uint collectionBadgesRootNodeHash)
        {
            Collectibles = collectibles.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyCollectibleDefinition, DestinyCollectibleComponent>(DefinitionsEnum.DestinyCollectibleDefinition);
            CollectionCategoriesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionCategoriesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            CollectionBadgesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionBadgesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
