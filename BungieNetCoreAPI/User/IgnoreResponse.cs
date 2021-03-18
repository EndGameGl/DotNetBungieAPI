using Newtonsoft.Json;

namespace NetBungieAPI.User
{
    public class IgnoreResponse
    {
        public bool IsIgnored { get; }
        public IgnoreStatus IgnoreFlags { get; }

        [JsonConstructor]
        internal IgnoreResponse(bool isIgnored, IgnoreStatus ignoreFlags)
        {
            IsIgnored = isIgnored;
            IgnoreFlags = ignoreFlags;
        }
    }
}
