using Newtonsoft.Json;

namespace NetBungieAPI.Trending
{
    public class TrendingEntryCommunityCreation
    {
        public string Media { get; }
        public string Title { get; }
        public string Author { get; }
        public long AuthorMembershipId { get; }
        public long PostId { get; }
        public string Body { get; }
        public int Upvotes { get; }

        [JsonConstructor]
        internal TrendingEntryCommunityCreation(string media, string title, string author, long authorMembershipId, long postId, string body, int upvotes)
        {
            Media = media;
            Title = title;
            Author = author;
            AuthorMembershipId = authorMembershipId;
            PostId = postId;
            Body = body;
            Upvotes = upvotes;
        }
    }
}
