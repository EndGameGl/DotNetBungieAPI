using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Bungie
{
    public class EmailOptInDefinition
    {
        public string Name { get; }
        public long Value { get; }
        public bool IsSetByDefault { get; }
        public ReadOnlyCollection<EmailSubscriptionDefinition> DependentSubscriptions { get; }

        [JsonConstructor]
        internal EmailOptInDefinition(string name, long value, bool setByDefault, EmailSubscriptionDefinition[] dependentSubscriptions)
        {
            Name = name;
            Value = value;
            IsSetByDefault = IsSetByDefault;
            DependentSubscriptions = dependentSubscriptions.AsReadOnlyOrEmpty();
        }
    }
}
