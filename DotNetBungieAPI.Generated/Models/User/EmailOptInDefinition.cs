namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Defines a single opt-in category: a wide-scoped permission to send emails for the subject related to the opt-in.
/// </summary>
public class EmailOptInDefinition : IDeepEquatable<EmailOptInDefinition>
{
    /// <summary>
    ///     The unique identifier for this opt-in category.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     The flag value for this opt-in category. For historical reasons, this is defined as a flags enum.
    /// </summary>
    [JsonPropertyName("value")]
    public User.OptInFlags Value { get; set; }

    /// <summary>
    ///     If true, this opt-in setting should be set by default in situations where accounts are created without explicit choices about what they're opting into.
    /// </summary>
    [JsonPropertyName("setByDefault")]
    public bool SetByDefault { get; set; }

    /// <summary>
    ///     Information about the dependent subscriptions for this opt-in.
    /// </summary>
    [JsonPropertyName("dependentSubscriptions")]
    public List<User.EmailSubscriptionDefinition> DependentSubscriptions { get; set; }

    public bool DeepEquals(EmailOptInDefinition? other)
    {
        return other is not null &&
               Name == other.Name &&
               Value == other.Value &&
               SetByDefault == other.SetByDefault &&
               DependentSubscriptions.DeepEqualsList(other.DependentSubscriptions);
    }
}