using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemPerksComponent
    {
        public ReadOnlyCollection<DestinyPerkReference> Perks { get; }

        [JsonConstructor]
        internal DestinyItemPerksComponent(DestinyPerkReference[] perks)
        {
            Perks = perks.AsReadOnlyOrEmpty();
        }
    }
}
