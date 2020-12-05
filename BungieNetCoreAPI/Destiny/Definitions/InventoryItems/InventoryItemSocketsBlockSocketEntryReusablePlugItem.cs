using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemSocketsBlockSocketEntryReusablePlugItem
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; }

        [JsonConstructor]
        private InventoryItemSocketsBlockSocketEntryReusablePlugItem(uint plugItemHash)
        {
            PlugItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(plugItemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
