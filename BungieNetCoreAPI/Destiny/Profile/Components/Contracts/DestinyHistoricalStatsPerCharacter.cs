using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsPerCharacter
    {
        public long CharacterId { get; init; }
        public bool IsDeleted { get; init; }
        public ReadOnlyDictionary<string, DestinyHistoricalStatsByPeriod> Results { get; init; }
        public DestinyHistoricalStatsByPeriod Merged { get; init; }
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
