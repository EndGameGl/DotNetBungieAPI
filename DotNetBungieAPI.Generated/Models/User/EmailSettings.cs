namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     The set of all email subscription/opt-in settings and definitions.
/// </summary>
public class EmailSettings : IDeepEquatable<EmailSettings>
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

    public bool DeepEquals(EmailSettings? other)
    {
        return other is not null &&
               OptInDefinitions.DeepEqualsDictionary(other.OptInDefinitions) &&
               SubscriptionDefinitions.DeepEqualsDictionary(other.SubscriptionDefinitions) &&
               Views.DeepEqualsDictionary(other.Views);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(EmailSettings? other)
    {
        if (other is null) return;
        if (!OptInDefinitions.DeepEqualsDictionary(other.OptInDefinitions))
        {
            OptInDefinitions = other.OptInDefinitions;
            OnPropertyChanged(nameof(OptInDefinitions));
        }
        if (!SubscriptionDefinitions.DeepEqualsDictionary(other.SubscriptionDefinitions))
        {
            SubscriptionDefinitions = other.SubscriptionDefinitions;
            OnPropertyChanged(nameof(SubscriptionDefinitions));
        }
        if (!Views.DeepEqualsDictionary(other.Views))
        {
            Views = other.Views;
            OnPropertyChanged(nameof(Views));
        }
    }
}