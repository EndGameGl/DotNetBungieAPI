using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPostGameCarnageReportExtendedData
    {
        public ReadOnlyCollection<DestinyHistoricalWeaponStats> Weapons { get; init; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; }

        [JsonConstructor]
        internal DestinyPostGameCarnageReportExtendedData(DestinyHistoricalWeaponStats[] weapons, Dictionary<string, DestinyHistoricalStatsValue> values)
        {
            Weapons = weapons.AsReadOnlyOrEmpty();
            Values = values.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
