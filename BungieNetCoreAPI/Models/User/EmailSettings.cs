using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record EmailSettings
    {
        [JsonPropertyName("optInDefinitions")]
        public ReadOnlyDictionary<string, EmailOptInDefinition> OptInDefinitions { get; init; } = Defaults.EmptyReadOnlyDictionary<string, EmailOptInDefinition>();
        
        [JsonPropertyName("subscriptionDefinitions")]             
        public ReadOnlyDictionary<string, EmailSubscriptionDefinition> SubscriptionDefinitions { get; init; } = Defaults.EmptyReadOnlyDictionary<string, EmailSubscriptionDefinition>();

        [JsonPropertyName("views")]
        public ReadOnlyDictionary<string, EmailViewDefinition> Views { get; init; } = Defaults.EmptyReadOnlyDictionary<string, EmailViewDefinition>();
    }
}
