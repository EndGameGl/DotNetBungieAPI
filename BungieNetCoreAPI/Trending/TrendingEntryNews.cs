using NetBungieAPI.Content;
using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingEntryNews
    {
        public ContentItemPublicContract Article { get; }

        [JsonConstructor]
        internal TrendingEntryNews(ContentItemPublicContract article)
        {
            Article = article;
        }
    }
}
