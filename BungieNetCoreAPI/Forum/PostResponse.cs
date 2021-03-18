using NetBungieAPI.User;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Forum
{
    public class PostResponse
    {
        public DateTime LastReplyTimestamp { get; }
        public bool IsPinned { get; }
        public ForumMediaType UrlMediaType { get; }
        public string Thumbnail { get; }
        public ForumPostPopularity Popularity { get; }
        public bool IsActive { get; }
        public bool IsAnnouncement { get; }
        public int UserRating { get; }
        public bool UserHasRated { get; }
        public bool UserHasMutedPost { get; }
        public long LatestReplyPostId { get; }
        public long LatestReplyAuthorId { get; }
        public IgnoreResponse IgnoreStatus { get; }
        public string Locale { get; }

        [JsonConstructor]
        internal PostResponse(DateTime lastReplyTimestamp, bool IsPinned, ForumMediaType urlMediaType, string thumbnail, ForumPostPopularity popularity,
            bool isActive, bool isAnnouncement, int userRating, bool userHasRated, bool userHasMutedPost, long latestReplyPostId, long latestReplyAuthorId,
            IgnoreResponse ignoreStatus, string locale)
        {
            LastReplyTimestamp = lastReplyTimestamp;
            this.IsPinned = IsPinned;
            UrlMediaType = urlMediaType;
            Thumbnail = thumbnail;
            Popularity = popularity;
            IsActive = isActive;
            IsAnnouncement = isAnnouncement;
            UserRating = userRating;
            UserHasRated = userHasRated;
            UserHasMutedPost = userHasMutedPost;
            LatestReplyPostId = latestReplyPostId;
            LatestReplyAuthorId = latestReplyAuthorId;
            IgnoreStatus = ignoreStatus;
            Locale = locale;
        }
    }
}
