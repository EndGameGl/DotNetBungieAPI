namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Localized text relevant to a given EMail setting in a given localization. Extra settings specifically for subscriptions.
/// </summary>
public class EMailSettingSubscriptionLocalization
{
    [JsonPropertyName("unknownUserDescription")]
    public string UnknownUserDescription { get; set; }

    [JsonPropertyName("registeredUserDescription")]
    public string RegisteredUserDescription { get; set; }

    [JsonPropertyName("unregisteredUserDescription")]
    public string UnregisteredUserDescription { get; set; }

    [JsonPropertyName("unknownUserActionText")]
    public string UnknownUserActionText { get; set; }

    [JsonPropertyName("knownUserActionText")]
    public string KnownUserActionText { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
