using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EmailSettings
{

    [JsonPropertyName("optInDefinitions")]
    public Dictionary<string, User.EmailOptInDefinition> OptInDefinitions { get; init; }

    [JsonPropertyName("subscriptionDefinitions")]
    public Dictionary<string, User.EmailSubscriptionDefinition> SubscriptionDefinitions { get; init; }

    [JsonPropertyName("views")]
    public Dictionary<string, User.EmailViewDefinition> Views { get; init; }
}
