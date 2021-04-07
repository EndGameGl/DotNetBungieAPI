using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public class EmailSubscriptionDefinition
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("localization")]
        public ReadOnlyDictionary<string, EmailSettingSubscriptionLocalization> Localization { get; init; } = Defaults.EmptyReadOnlyDictionary<string, EmailSettingSubscriptionLocalization>();

        [JsonPropertyName("value")]
        public long Value { get; init; }
    }
}
