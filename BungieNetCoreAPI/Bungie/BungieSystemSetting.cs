using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie
{
    public class BungieSystemSetting
    {
        public bool IsEnabled { get; }
        public ReadOnlyDictionary<string, string> Parameters { get; }

        [JsonConstructor]
        internal BungieSystemSetting(bool enabled, Dictionary<string, string> parameters)
        {
            IsEnabled = enabled;
            Parameters = parameters.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
