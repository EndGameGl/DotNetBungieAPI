using Newtonsoft.Json;

namespace NetBungieApi.Bungie
{
    public class BungieNetUserContext
    {
        public bool IsFollowing { get; }
        public BungieNetUserContextIgnoreStatus IgnoreStatus { get; }

        [JsonConstructor]
        internal BungieNetUserContext(bool isFollowing, BungieNetUserContextIgnoreStatus ignoreStatus)
        {
            IsFollowing = isFollowing;
            IgnoreStatus = ignoreStatus;
        }
    }
}
