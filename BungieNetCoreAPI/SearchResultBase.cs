using NetBungieAPI.Responses;
using Newtonsoft.Json;

namespace NetBungieAPI
{
    public abstract class SearchResultBase
    {
        public int TotalResults { get; }
        public bool HasMore { get; }
        public PagedQuery Query { get; }
        public string ReplacementContinuationToken { get; }
        public bool UseTotalResults { get; }

        [JsonConstructor]
        internal SearchResultBase(int totalResults, bool hasMore, PagedQuery query, string replacementContinuationToken, bool useTotalResults)
        {
            TotalResults = totalResults;
            HasMore = hasMore;
            Query = query;
            ReplacementContinuationToken = replacementContinuationToken;
            UseTotalResults = useTotalResults;
        }
    }
}
