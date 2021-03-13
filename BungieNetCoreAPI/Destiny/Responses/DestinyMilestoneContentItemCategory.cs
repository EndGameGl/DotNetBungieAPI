using NetBungieApi.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Responses
{
    public class DestinyMilestoneContentItemCategory
    {
        public string Title { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> Items { get; }

        [JsonConstructor]
        internal DestinyMilestoneContentItemCategory(string title, uint[] itemHashes)
        {
            Title = title;
            Items = itemHashes.DefinitionsAsReadOnlyOrEmpty<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
