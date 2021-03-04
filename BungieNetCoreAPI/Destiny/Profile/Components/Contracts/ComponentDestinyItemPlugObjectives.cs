﻿using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemPlugObjectives
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<DestinyObjectiveProgress>> ObjectivesPerPlug { get; }

        [JsonConstructor]
        internal ComponentDestinyItemPlugObjectives(Dictionary<uint, DestinyObjectiveProgress[]> objectivesPerPlug)
        {
            ObjectivesPerPlug = objectivesPerPlug
                .ToDictionary(x => x.Key, x => x.Value.AsReadOnlyOrEmpty())
                .AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyInventoryItemDefinition, ReadOnlyCollection<DestinyObjectiveProgress>>(DefinitionsEnum.DestinyInventoryItemDefinition);
        }
    }
}