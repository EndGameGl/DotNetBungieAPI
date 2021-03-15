using Newtonsoft.Json;

namespace NetBungieAPI.Bungie
{
    public class BungieNetUserContextIgnoreStatus
    {
        public bool IsIgnored { get; }
        public int IgnoreFlags { get; }

        [JsonConstructor]
        internal BungieNetUserContextIgnoreStatus(bool isIgnored, int ignoreFlags)
        {
            IsIgnored = isIgnored;
            IgnoreFlags = ignoreFlags;
        }
    }
}
