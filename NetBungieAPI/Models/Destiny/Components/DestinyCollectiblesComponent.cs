using NetBungieAPI.Models.Destiny.Definitions.Collectibles;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCollectiblesComponent
    {
        [JsonPropertyName("collectibles")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>, DestinyCollectibleComponent>
            Collectibles { get; init; } =
            Defaults
                .EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyCollectibleDefinition>,
                    DestinyCollectibleComponent>();

        /// <summary>
        /// The hash for the root presentation node definition of Collection categories.
        /// </summary>
        [JsonPropertyName("collectionCategoriesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionCategoriesRootNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        /// <summary>
        /// The hash for the root presentation node definition of Collection Badges.
        /// </summary>
        [JsonPropertyName("collectionBadgesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionBadgesRootNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}