using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingCategory
    {
        public string CategoryName { get; }
        public SearchResult<TrendingEntry> Entries { get; }
        public string CategoryId { get; }

        [JsonConstructor]
        internal TrendingCategory(string categoryName, SearchResult<TrendingEntry> entries, string categoryId)
        {
            CategoryName = categoryName;
            Entries = entries;
            CategoryId = categoryId;
        }
    }
}
