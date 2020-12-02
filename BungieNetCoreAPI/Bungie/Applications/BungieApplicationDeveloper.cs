using Newtonsoft.Json;

namespace BungieNetCoreAPI.Bungie.Applications
{
    public class BungieApplicationDeveloper
    {
        public int Role { get; }
        public int ApiEulaVersion { get; }
        public BungieNetUserInfo User { get; }

        [JsonConstructor]
        private BungieApplicationDeveloper(int role, int apiEulaVersion, BungieNetUserInfo user)
        {
            Role = role;
            ApiEulaVersion = apiEulaVersion;
            User = user;
        }
    }
}
