using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Bungie
{
    public class BungieNetEmailSettings
    {
        public Dictionary<string, EmailOptInDefinition> OptInDefinitions { get; }
        public Dictionary<string, EmailSubscriptionDefinition> SubscriptionDefinitions { get; }
        public Dictionary<string, EmailViewDefinition> ViewsDefinitions { get; }

        [JsonConstructor]
        internal BungieNetEmailSettings(
            Dictionary<string, EmailOptInDefinition> optInDefinitions, 
            Dictionary<string, EmailSubscriptionDefinition> subscriptionDefinitions, 
            Dictionary<string, EmailViewDefinition> views)
        {
            OptInDefinitions = optInDefinitions;
            SubscriptionDefinitions = subscriptionDefinitions;
            ViewsDefinitions = views;
        }
    }
}
