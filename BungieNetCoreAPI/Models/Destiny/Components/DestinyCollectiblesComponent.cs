using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCollectiblesComponent
    {
        [JsonPropertyName("collectibles")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent> Collectibles { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent>();
        [JsonPropertyName("collectionCategoriesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
        [JsonPropertyName("collectionBadgesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}
