using BungieNetCoreAPI.Destiny.Definitions.PowerCaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemQualityBlockVersion
    {
        public DefinitionHashPointer<DestinyPowerCapDefinition> PowerCap { get; }

        [JsonConstructor]
        private InventoryItemQualityBlockVersion(uint powerCapHash)
        {
            PowerCap = new DefinitionHashPointer<DestinyPowerCapDefinition>(powerCapHash, "DestinyPowerCapDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
