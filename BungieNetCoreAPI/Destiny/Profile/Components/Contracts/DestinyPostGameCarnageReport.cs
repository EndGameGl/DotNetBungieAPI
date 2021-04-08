using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPostGameCarnageReport
    {
        public int Standing { get; init; }
        public DestinyHistoricalStatsValue Score { get; init; }
        public DestinyPlayer Player { get; init; }
        public long CharacterId { get; init; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; }
        public DestinyPostGameCarnageReportExtendedData ExtendedData { get; init; }

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
