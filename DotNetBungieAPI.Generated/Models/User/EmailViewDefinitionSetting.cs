using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EmailViewDefinitionSetting
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("localization")]
    public Dictionary<string, User.EMailSettingLocalization> Localization { get; init; }

    [JsonPropertyName("setByDefault")]
    public bool SetByDefault { get; init; }

    [JsonPropertyName("optInAggregateValue")]
    public User.OptInFlags OptInAggregateValue { get; init; }

    [JsonPropertyName("subscriptions")]
    public List<User.EmailSubscriptionDefinition> Subscriptions { get; init; }
}
