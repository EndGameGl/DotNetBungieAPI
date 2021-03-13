using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie
{
    public class EmailViewDefinitionSetting
    {
        public string Name { get; }
        public ReadOnlyDictionary<string, EmailSettingLocalization> Localization { get; }
        public bool IsSetByDefault { get; }
        public long OptInAggregateValue { get; }
        public ReadOnlyCollection<EmailSubscriptionDefinition> Subscriptions { get; }

        [JsonConstructor]
        internal EmailViewDefinitionSetting(string name, Dictionary<string, EmailSettingLocalization> localization, bool setByDefault, long optInAggregateValue,
             EmailSubscriptionDefinition[] subscriptions)
        {
            Name = name;
            Localization = localization.AsReadOnlyDictionaryOrEmpty();
            IsSetByDefault = setByDefault;
            OptInAggregateValue = optInAggregateValue;
            Subscriptions = subscriptions.AsReadOnlyOrEmpty();
        }
    }
}
