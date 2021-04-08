using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCollectiblesComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent> Collectibles { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; init; }

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
