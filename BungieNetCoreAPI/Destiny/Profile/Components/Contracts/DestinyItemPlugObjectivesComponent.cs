using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemPlugObjectivesComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<DestinyObjectiveProgress>> ObjectivesPerPlug { get; init; }

        [JsonConstructor]
        internal DestinyItemPlugObjectivesComponent(Dictionary<uint, DestinyObjectiveProgress[]> objectivesPerPlug)
        {
            ObjectivesPerPlug = objectivesPerPlug?
                .ToDictionary(x => x.Key, x => x.Value.AsReadOnlyOrEmpty())
                .AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyInventoryItemDefinition, ReadOnlyCollection<DestinyObjectiveProgress>>(DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}
