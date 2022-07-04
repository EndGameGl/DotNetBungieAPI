namespace DotNetBungieAPI.Models.User;

/// <summary>
///     Defines a single subscription: permission to send emails for a specific, focused subject (generally timeboxed, such
///     as for a specific release of a product or feature).
/// </summary>
public sealed record EmailSubscriptionDefinition
{
    /// <summary>
    ///     The unique identifier for this subscription.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    ///     A dictionary of localized text for the EMail Opt-in setting, keyed by the locale.
    /// </summary>
    [JsonPropertyName("localization")]
    public ReadOnlyDictionary<string, EmailSettingSubscriptionLocalization> Localization { get; init; } =
        ReadOnlyDictionaries<string, EmailSettingSubscriptionLocalization>.Empty;

    /// <summary>
    ///     The bitflag value for this subscription. Should be a unique power of two value.
    /// </summary>
    [JsonPropertyName("value")]
    public long Value { get; init; }
}