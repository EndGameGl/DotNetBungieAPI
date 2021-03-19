using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingDetail
    {
        public string Identifier { get; }
        public TrendingEntryType EntityType { get; }
        public TrendingEntryNews News { get; }
        public TrendingEntrySupportArticle Support { get; }
        public TrendingEntryDestinyItem DestinyItem { get; }
        public TrendingEntryDestinyActivity DestinyActivity { get; }
        public TrendingEntryDestinyRitual DestinyRitual { get; }
        public TrendingEntryCommunityCreation Creation { get; }

        [JsonConstructor]
        internal TrendingDetail(string identifier, TrendingEntryType entityType, TrendingEntryNews news, TrendingEntrySupportArticle support,
            TrendingEntryDestinyItem destinyItem, TrendingEntryDestinyActivity destinyActivity, TrendingEntryDestinyRitual destinyRitual,
            TrendingEntryCommunityCreation creation)
        {
            Identifier = identifier;
            EntityType = entityType;
            News = news;
            Support = support;
            DestinyItem = destinyItem;
            DestinyActivity = destinyActivity;
            DestinyRitual = destinyRitual;
            Creation = creation;
        }
    }
}
