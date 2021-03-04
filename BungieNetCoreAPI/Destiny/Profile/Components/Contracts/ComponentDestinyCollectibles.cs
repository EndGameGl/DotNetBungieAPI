using BungieNetCoreAPI.Destiny.Definitions.Collectibles;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyCollectibles
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent> Collectibles { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; }

        [JsonConstructor]
        internal ComponentDestinyCollectibles(Dictionary<uint, DestinyCollectibleComponent> collectibles, uint collectionCategoriesRootNodeHash,
            uint collectionBadgesRootNodeHash)
        {
            Collectibles = collectibles.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyCollectibleDefinition, DestinyCollectibleComponent>(DefinitionsEnum.DestinyCollectibleDefinition);
            CollectionCategoriesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionCategoriesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            CollectionBadgesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionBadgesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
