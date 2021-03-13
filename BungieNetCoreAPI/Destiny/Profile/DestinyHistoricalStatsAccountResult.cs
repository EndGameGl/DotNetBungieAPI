using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyHistoricalStatsAccountResult
    {
        public DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; }
        public DestinyHistoricalStatsWithMerged MergedAllCharacters { get; }
        public ReadOnlyCollection<DestinyHistoricalStatsPerCharacter> Characters { get; }

        [JsonConstructor]
        internal DestinyHistoricalStatsAccountResult(
            DestinyHistoricalStatsWithMerged mergedDeletedCharacters, 
            DestinyHistoricalStatsWithMerged mergedAllCharacters,
            DestinyHistoricalStatsPerCharacter[] characters)
        {
            MergedDeletedCharacters = mergedDeletedCharacters;
            MergedAllCharacters = mergedAllCharacters;
            Characters = characters.AsReadOnlyOrEmpty();
        }
    }
}
