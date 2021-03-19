using NetBungieAPI.Content;
using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingEntrySupportArticle
    {
        public ContentItemPublicContract Article { get; }

        [JsonConstructor]
        internal TrendingEntrySupportArticle(ContentItemPublicContract article)
        {
            Article = article;
        }
    }
}
