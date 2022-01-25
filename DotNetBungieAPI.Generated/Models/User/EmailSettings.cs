namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     The set of all email subscription/opt-in settings and definitions.
/// </summary>
public class EmailSettings
{
    /// <summary>
    ///     Keyed by the name identifier of the opt-in definition.
    /// </summary>
    [JsonPropertyName("optInDefinitions")]
    public Dictionary<string, User.EmailOptInDefinition> OptInDefinitions { get; set; }

    /// <summary>
    ///     Keyed by the name identifier of the Subscription definition.
    /// </summary>
    [JsonPropertyName("subscriptionDefinitions")]
    public Dictionary<string, User.EmailSubscriptionDefinition> SubscriptionDefinitions { get; set; }

    /// <summary>
    ///     Keyed by the name identifier of the View definition.
    /// </summary>
    [JsonPropertyName("views")]
    public Dictionary<string, User.EmailViewDefinition> Views { get; set; }
}
