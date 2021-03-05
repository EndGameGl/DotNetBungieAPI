using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPostGameCarnageReport
    {
        public int Standing { get; }
        public DestinyHistoricalStatsValue Score { get; }
        public DestinyPlayer Player { get; }
        public long CharacterId { get; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; }
        public DestinyPostGameCarnageReportExtendedData ExtendedData { get; }

        [JsonConstructor]
        internal DestinyPostGameCarnageReport(int standing, DestinyHistoricalStatsValue score, DestinyPlayer player, long characterId,
            Dictionary<string, DestinyHistoricalStatsValue> values, DestinyPostGameCarnageReportExtendedData extended)
        {
            Standing = standing;
            Score = score;
            Player = player;
            CharacterId = characterId;
            Values = values.AsReadOnlyDictionaryOrEmpty();
            ExtendedData = extended;
        }
    }
}
