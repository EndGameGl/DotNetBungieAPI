using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Bungie
{
    public class EmailSubscriptionDefinition
    {
        public string Name { get; }
        public Dictionary<string, EmailSettingSubscriptionLocalization> Localization { get; }
        public long Value { get; }

        [JsonConstructor]
        internal EmailSubscriptionDefinition(string name, Dictionary<string, EmailSettingSubscriptionLocalization> localization, long value)
        {
            Name = name;
            Localization = localization;
            Value = value;
        }
    }
}
