using BungieNetCoreAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile
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
