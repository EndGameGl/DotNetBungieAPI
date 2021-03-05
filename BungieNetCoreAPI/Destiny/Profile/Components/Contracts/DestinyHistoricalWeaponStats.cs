using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalWeaponStats
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ItemReference { get; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; }

        [JsonConstructor]
        internal DestinyHistoricalWeaponStats(uint referenceId, Dictionary<string, DestinyHistoricalStatsValue> values)
        {
            ItemReference = new DefinitionHashPointer<DestinyInventoryItemDefinition>(referenceId, DefinitionsEnum.DestinyInventoryItemDefinition);
            Values = values.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
