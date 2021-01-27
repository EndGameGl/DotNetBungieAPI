using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Bungie
{
    public class EmailViewDefinitionSetting
    {
        public string Name { get; }
        public Dictionary<string, EmailSettingLocalization> Localization { get; }
        public bool IsSetByDefault { get; }
        public long OptInAggregateValue { get; }
        public EmailSubscriptionDefinition[] Subscriptions { get; }

        [JsonConstructor]
        internal EmailViewDefinitionSetting(string name, Dictionary<string, EmailSettingLocalization> localization, bool setByDefault, long optInAggregateValue,
             EmailSubscriptionDefinition[] subscriptions)
        {
            Name = name;
            Localization = localization;
            IsSetByDefault = setByDefault;
            OptInAggregateValue = optInAggregateValue;
            Subscriptions = subscriptions;
        }
    }
}
