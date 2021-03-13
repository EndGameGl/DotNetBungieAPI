using NetBungieApi.Destiny.Definitions.PresentationNodes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// The metrics available for display and selection on an item.
    /// </summary>
    public class InventoryItemMetricBlock : IDeepEquatable<InventoryItemMetricBlock>
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> AvailableMetricCategoryNodes { get; }

        [JsonConstructor]
        internal InventoryItemMetricBlock(uint[] availableMetricCategoryNodeHashes)
        {
            AvailableMetricCategoryNodes = availableMetricCategoryNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
        }

        public bool DeepEquals(InventoryItemMetricBlock other)
        {
            return other != null &&
                   AvailableMetricCategoryNodes.DeepEqualsReadOnlyCollections(other.AvailableMetricCategoryNodes);
        }
    }
}
