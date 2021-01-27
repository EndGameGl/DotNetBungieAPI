using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieSystemSetting
    {
        public bool IsEnabled { get; }
        public Dictionary<string, string> Parameters { get; }

        [JsonConstructor]
        internal BungieSystemSetting(bool enabled, Dictionary<string, string> parameters)
        {
            IsEnabled = enabled;
            Parameters = parameters;
        }
    }
}
