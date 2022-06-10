namespace DotNetBungieAPI.Generated.Models.User;

public class EmailViewDefinitionSetting
{
    /// <summary>
    ///     The identifier for this UI Setting, which can be used to relate it to custom strings or other data as desired.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     A dictionary of localized text for the EMail setting, keyed by the locale.
    /// </summary>
    [JsonPropertyName("localization")]
    public Dictionary<string, User.EMailSettingLocalization> Localization { get; set; }

    /// <summary>
    ///     If true, this setting should be set by default if the user hasn't chosen whether it's set or cleared yet.
    /// </summary>
    [JsonPropertyName("setByDefault")]
    public bool SetByDefault { get; set; }

    /// <summary>
    ///     The OptInFlags value to set or clear if this setting is set or cleared in the UI. It is the aggregate of all underlying opt-in flags related to this setting.
    /// </summary>
    [JsonPropertyName("optInAggregateValue")]
    public User.OptInFlags OptInAggregateValue { get; set; }

    /// <summary>
    ///     The subscriptions to show as children of this setting, if any.
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public List<User.EmailSubscriptionDefinition> Subscriptions { get; set; }
}
