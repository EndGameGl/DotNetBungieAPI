using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Responses
{
    public class DestinyEntitySearchResult
    {
        public ReadOnlyCollection<string> SuggestedWords { get; }
        public SearchResultOfDestinyEntitySearch Results { get; }

        [JsonConstructor]
        internal DestinyEntitySearchResult(string[] suggestedWords, SearchResultOfDestinyEntitySearch results)
        {
            SuggestedWords = suggestedWords.AsReadOnlyOrEmpty();
            Results = results;
        }
    }
}
