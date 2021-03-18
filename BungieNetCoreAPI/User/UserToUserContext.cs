using Newtonsoft.Json;
using System;

namespace NetBungieAPI.User
{
    public class UserToUserContext
    {
        public bool IsFollowing { get; }
        public IgnoreResponse IgnoreStatus { get; }
        public DateTime? GlobalIgnoreEndDate { get; }

        [JsonConstructor]
        internal UserToUserContext(bool isFollowing, IgnoreResponse ignoreStatus, DateTime? globalIgnoreEndDate)
        {
            IsFollowing = isFollowing;
            IgnoreStatus = ignoreStatus;
            GlobalIgnoreEndDate = globalIgnoreEndDate;
        }
    }
}
