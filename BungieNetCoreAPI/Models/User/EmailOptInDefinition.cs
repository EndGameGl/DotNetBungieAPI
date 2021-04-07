using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record EmailOptInDefinition
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("value")]
        public long Value { get; init; }

        [JsonPropertyName("setByDefault")]
        public bool IsSetByDefault { get; init; }

        [JsonPropertyName("dependentSubscriptions")]
        public ReadOnlyCollection<EmailSubscriptionDefinition> DependentSubscriptions { get; init; } = Defaults.EmptyReadOnlyCollection<EmailSubscriptionDefinition>();
    }
}
