using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record EmailViewDefinitionSetting
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("localization")]
        public ReadOnlyDictionary<string, EmailSettingLocalization> Localization { get; init; } = Defaults.EmptyReadOnlyDictionary<string, EmailSettingLocalization>();

        [JsonPropertyName("setByDefault")]
        public bool IsSetByDefault { get; init; }

        [JsonPropertyName("optInAggregateValue")]
        public OptInFlags OptInAggregateValue { get; init; }

        [JsonPropertyName("subscriptions")]
        public ReadOnlyCollection<EmailSubscriptionDefinition> Subscriptions { get; init; } = Defaults.EmptyReadOnlyCollection<EmailSubscriptionDefinition>();
    }
}
