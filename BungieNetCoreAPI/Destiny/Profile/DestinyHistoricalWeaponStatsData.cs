using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyHistoricalWeaponStatsData
    {
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; }

        [JsonConstructor]
        internal DestinyHistoricalWeaponStatsData(DestinyHistoricalWeaponStats[] weapons)
        {
            Weapons = weapons.AsReadOnlyOrEmpty();
        }
    }
}
