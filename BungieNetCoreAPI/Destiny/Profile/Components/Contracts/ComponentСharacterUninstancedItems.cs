using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentСharacterUninstancedItems
    {
        public DestinyProfileComponent<Dictionary<uint, ComponentDestinyItemObjectives>> Objectives { get; }

        [JsonConstructor]
        internal ComponentСharacterUninstancedItems(DestinyProfileComponent<Dictionary<uint, ComponentDestinyItemObjectives>> objectives)
        {
            Objectives = objectives;
        }
    }
}
