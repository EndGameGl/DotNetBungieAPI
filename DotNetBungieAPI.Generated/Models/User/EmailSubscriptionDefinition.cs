using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EmailSubscriptionDefinition
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("localization")]
    public Dictionary<string, User.EMailSettingSubscriptionLocalization> Localization { get; init; }

    [JsonPropertyName("value")]
    public long Value { get; init; }
}
