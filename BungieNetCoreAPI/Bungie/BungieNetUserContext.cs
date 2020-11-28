using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetUserContext
    {
        public bool IsFollowing { get; }
        public BungieNetUserContextIgnoreStatus IgnoreStatus { get; }

        [JsonConstructor]
        private BungieNetUserContext(bool isFollowing, BungieNetUserContextIgnoreStatus ignoreStatus)
        {
            IsFollowing = isFollowing;
            IgnoreStatus = ignoreStatus;
        }
    }
}
