using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets
{
    public class MaterialRequirementSetEntry
    {
        public int Count { get; }
        public bool DeleteOnAction { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public bool OmitFromRequirements { get; }

        [JsonConstructor]
        private MaterialRequirementSetEntry(int count, bool deleteOnAction, uint itemHash, bool omitFromRequirements)
        {
            Count = count;
            DeleteOnAction = deleteOnAction;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, "DestinyInventoryItemDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            OmitFromRequirements = omitFromRequirements;
        }
    }
}
