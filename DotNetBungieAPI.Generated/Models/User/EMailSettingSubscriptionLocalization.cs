using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Localized text relevant to a given EMail setting in a given localization. Extra settings specifically for subscriptions.
/// </summary>
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
