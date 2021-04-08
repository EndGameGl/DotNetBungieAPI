using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyHistoricalStatsAccountResult
    {
        public DestinyHistoricalStatsWithMerged MergedDeletedCharacters { get; init; }
        public DestinyHistoricalStatsWithMerged MergedAllCharacters { get; init; }
        public ReadOnlyCollection<DestinyHistoricalStatsPerCharacter> Characters { get; init; }

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
