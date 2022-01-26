namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Defines a single subscription: permission to send emails for a specific, focused subject (generally timeboxed, such as for a specific release of a product or feature).
/// </summary>
public class EmailSubscriptionDefinition : IDeepEquatable<EmailSubscriptionDefinition>
{
    /// <summary>
    ///     The unique identifier for this subscription.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     A dictionary of localized text for the EMail Opt-in setting, keyed by the locale.
    /// </summary>
    [JsonPropertyName("localization")]
    public Dictionary<string, User.EMailSettingSubscriptionLocalization> Localization { get; set; }

    /// <summary>
    ///     The bitflag value for this subscription. Should be a unique power of two value.
    /// </summary>
    [JsonPropertyName("value")]
    public long Value { get; set; }

    public bool DeepEquals(EmailSubscriptionDefinition? other)
    {
        return other is not null &&
               Name == other.Name &&
               Localization.DeepEqualsDictionary(other.Localization) &&
               Value == other.Value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(EmailSubscriptionDefinition? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (!Localization.DeepEqualsDictionary(other.Localization))
        {
            Localization = other.Localization;
            OnPropertyChanged(nameof(Localization));
        }
        if (Value != other.Value)
        {
            Value = other.Value;
            OnPropertyChanged(nameof(Value));
        }
    }
}