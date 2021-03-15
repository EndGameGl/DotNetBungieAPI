using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsPerCharacter
    {
        public long CharacterId { get; }
        public bool IsDeleted { get; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; }
        public DestinyHistoricalStatsByPeriod Merged { get; }
        [JsonConstructor]
        internal DestinyHistoricalStatsPerCharacter(long characterId, bool deleted, Dictionary<string, DestinyHistoricalStatsByPeriod> results,
            DestinyHistoricalStatsByPeriod merged)
        {
            CharacterId = characterId;
            IsDeleted = deleted;
            Results = results.AsReadOnlyDictionaryOrEmpty();
            Merged = merged;
        }
    }
}
