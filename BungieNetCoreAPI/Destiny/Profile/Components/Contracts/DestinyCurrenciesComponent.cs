using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCurrenciesComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, object> ItemQuantities;
        [JsonConstructor]
        internal DestinyCurrenciesComponent(Dictionary<uint, object> itemQuantities)
        {
            ItemQuantities = itemQuantities.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyInventoryItemDefinition, object>(DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
