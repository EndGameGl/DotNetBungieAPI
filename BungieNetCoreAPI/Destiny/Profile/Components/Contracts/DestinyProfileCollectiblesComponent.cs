using NetBungieAPI.Destiny.Definitions.Collectibles;
using NetBungieAPI.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileCollectiblesComponent
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyCollectibleDefinition>> RecentCollectibles { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyCollectibleDefinition>> NewnessFlaggedCollectibles { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent> Collectibles { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; init; }
        [JsonConstructor]
        internal DestinyProfileCollectiblesComponent(uint[] recentCollectibleHashes, uint[] newnessFlaggedCollectibleHashes, 
            Dictionary<uint, DestinyCollectibleComponent> collectibles, uint collectionCategoriesRootNodeHash, uint collectionBadgesRootNodeHash) 
        {
            RecentCollectibles = recentCollectibleHashes.DefinitionsAsReadOnlyOrEmpty<DestinyCollectibleDefinition>(DefinitionsEnum.DestinyCollectibleDefinition);
            NewnessFlaggedCollectibles = newnessFlaggedCollectibleHashes.DefinitionsAsReadOnlyOrEmpty<DestinyCollectibleDefinition>(DefinitionsEnum.DestinyCollectibleDefinition);
            Collectibles = collectibles.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyCollectibleDefinition, DestinyCollectibleComponent>(DefinitionsEnum.DestinyCollectibleDefinition);
            CollectionCategoriesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionCategoriesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            CollectionBadgesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(collectionBadgesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
