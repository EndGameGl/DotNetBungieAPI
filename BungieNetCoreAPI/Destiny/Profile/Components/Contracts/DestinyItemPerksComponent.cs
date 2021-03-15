using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
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
