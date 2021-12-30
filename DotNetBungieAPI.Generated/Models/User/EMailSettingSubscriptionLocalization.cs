using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

public sealed class EMailSettingSubscriptionLocalization
{

    [JsonPropertyName("unknownUserDescription")]
    public string UnknownUserDescription { get; init; }

    [JsonPropertyName("registeredUserDescription")]
    public string RegisteredUserDescription { get; init; }

    [JsonPropertyName("unregisteredUserDescription")]
    public string UnregisteredUserDescription { get; init; }

    [JsonPropertyName("unknownUserActionText")]
    public string UnknownUserActionText { get; init; }

    [JsonPropertyName("knownUserActionText")]
    public string KnownUserActionText { get; init; }

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }
}
