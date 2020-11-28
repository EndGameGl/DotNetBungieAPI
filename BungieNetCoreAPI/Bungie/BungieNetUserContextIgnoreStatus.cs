using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetUserContextIgnoreStatus
    {
        public bool IsIgnored { get; }
        public int IgnoreFlags { get; }

        [JsonConstructor]
        private BungieNetUserContextIgnoreStatus(bool isIgnored, int ignoreFlags)
        {
            IsIgnored = isIgnored;
            IgnoreFlags = ignoreFlags;
        }
    }
}
