using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie
{
    public class EmailSubscriptionDefinition
    {
        public string Name { get; }
        public ReadOnlyDictionary<string, EmailSettingSubscriptionLocalization> Localization { get; }
        public long Value { get; }

        [JsonConstructor]
        internal EmailSubscriptionDefinition(string name, Dictionary<string, EmailSettingSubscriptionLocalization> localization, long value)
        {
            Name = name;
            Localization = localization.AsReadOnlyDictionaryOrEmpty();
            Value = value;
        }
    }
}
