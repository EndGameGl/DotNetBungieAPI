using Newtonsoft.Json;

namespace NetBungieApi.Bungie.Applications
{
    public class BungieApplicationDeveloper
    {
        public int Role { get; }
        public int ApiEulaVersion { get; }
        public BungieNetUserInfo User { get; }

        [JsonConstructor]
        internal BungieApplicationDeveloper(int role, int apiEulaVersion, BungieNetUserInfo user)
        {
            Role = role;
            ApiEulaVersion = apiEulaVersion;
            User = user;
        }
    }
}
