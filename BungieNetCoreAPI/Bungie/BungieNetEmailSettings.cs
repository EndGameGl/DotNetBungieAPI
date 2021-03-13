using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Bungie
{
    public class BungieNetEmailSettings
    {
        public ReadOnlyDictionary<string, EmailOptInDefinition> OptInDefinitions { get; }
        public ReadOnlyDictionary<string, EmailSubscriptionDefinition> SubscriptionDefinitions { get; }
        public ReadOnlyDictionary<string, EmailViewDefinition> ViewsDefinitions { get; }

        [JsonConstructor]
        internal BungieNetEmailSettings(
            Dictionary<string, EmailOptInDefinition> optInDefinitions, 
            Dictionary<string, EmailSubscriptionDefinition> subscriptionDefinitions, 
            Dictionary<string, EmailViewDefinition> views)
        {
            OptInDefinitions = optInDefinitions.AsReadOnlyDictionaryOrEmpty();
            SubscriptionDefinitions = subscriptionDefinitions.AsReadOnlyDictionaryOrEmpty();
            ViewsDefinitions = views.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
