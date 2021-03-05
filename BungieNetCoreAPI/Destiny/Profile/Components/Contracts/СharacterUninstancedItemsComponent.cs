using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class СharacterUninstancedItemsComponent
    {
        public DestinyProfileComponent<Dictionary<uint, DestinyItemObjectivesComponent>> Objectives { get; }

        [JsonConstructor]
        internal СharacterUninstancedItemsComponent(DestinyProfileComponent<Dictionary<uint, DestinyItemObjectivesComponent>> objectives)
        {
            Objectives = objectives;
        }
    }
}
