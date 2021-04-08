using NetBungieAPI.Models.Queries;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Responses
{
    public class SearchResultOfDestinyEntitySearch
    {
        public ReadOnlyCollection<DestinyEntitySearchResultItem> Results { get; init; }
        public int TotalResults { get; init; }
        public bool HasMore { get; init; }
        public PagedQuery Query { get; init; }
        public string ReplacementContinuationToken { get; init; }
        public bool UseTotalResults { get; init; }

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
