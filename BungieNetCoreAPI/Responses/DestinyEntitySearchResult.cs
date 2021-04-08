using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Responses
{
    public class DestinyEntitySearchResult
    {
        public ReadOnlyCollection<string> SuggestedWords { get; init; }
        public SearchResultOfDestinyEntitySearch Results { get; init; }

        [JsonConstructor]
        internal DestinyEntitySearchResult(string[] suggestedWords, SearchResultOfDestinyEntitySearch results)
        {
            SuggestedWords = suggestedWords.AsReadOnlyOrEmpty();
            Results = results;
        }
    }
}
