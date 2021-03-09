using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyHistoricalWeaponStatsData
    {
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; }

        [JsonConstructor]
        internal DestinyHistoricalWeaponStatsData(DestinyHistoricalWeaponStats[] weapons)
        {
            Weapons = weapons.AsReadOnlyOrEmpty();
        }
    }
}
