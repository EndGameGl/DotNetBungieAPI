using Newtonsoft.Json;

namespace BungieNetCoreAPI.Responses
{
    public class PagedQuery
    {
        public int ItemsPerPage { get; }
        public int CurrentPage { get; }
        public string RequestContinuationToken { get; }

        [JsonConstructor]
        internal PagedQuery(int itemsPerPage, int currentPage, string requestContinuationToken)
        {
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
            RequestContinuationToken = requestContinuationToken;
        }
    }
}
