using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyItemPerks
    {
        public ReadOnlyCollection<DestinyPerkReference> Perks { get; }

        [JsonConstructor]
        internal ComponentDestinyItemPerks(DestinyPerkReference[] perks)
        {
            Perks = perks.AsReadOnlyOrEmpty();
        }
    }
}
