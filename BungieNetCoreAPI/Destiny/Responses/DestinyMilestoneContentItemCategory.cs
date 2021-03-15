using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Responses
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
