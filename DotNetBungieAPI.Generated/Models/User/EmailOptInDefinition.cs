using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EmailOptInDefinition
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("value")]
    public User.OptInFlags Value { get; init; }

    [JsonPropertyName("setByDefault")]
    public bool SetByDefault { get; init; }

    [JsonPropertyName("dependentSubscriptions")]
    public List<User.EmailSubscriptionDefinition> DependentSubscriptions { get; init; }
}
