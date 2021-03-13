using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Responses
{
    public class SearchResultOfDestinyEntitySearch
    {
        public ReadOnlyCollection<DestinyEntitySearchResultItem> Results { get; }
        public int TotalResults { get; }
        public bool HasMore { get; }
        public PagedQuery Query { get; }
        public string ReplacementContinuationToken { get; }
        public bool UseTotalResults { get; }

        [JsonConstructor]
        internal SearchResultOfDestinyEntitySearch(DestinyEntitySearchResultItem[] results, int totalResults, bool hasMore, PagedQuery query, 
            string replacementContinuationToken, bool useTotalResults)
        {
            Results = results.AsReadOnlyOrEmpty();
            TotalResults = totalResults;
            HasMore = hasMore;
            Query = query;
            ReplacementContinuationToken = replacementContinuationToken;
            UseTotalResults = useTotalResults;
        }
    }
}
