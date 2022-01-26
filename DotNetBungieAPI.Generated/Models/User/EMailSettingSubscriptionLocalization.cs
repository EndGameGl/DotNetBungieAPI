namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Localized text relevant to a given EMail setting in a given localization. Extra settings specifically for subscriptions.
/// </summary>
public class EMailSettingSubscriptionLocalization : IDeepEquatable<EMailSettingSubscriptionLocalization>
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

    public bool DeepEquals(EMailSettingSubscriptionLocalization? other)
    {
        return other is not null &&
               UnknownUserDescription == other.UnknownUserDescription &&
               RegisteredUserDescription == other.RegisteredUserDescription &&
               UnregisteredUserDescription == other.UnregisteredUserDescription &&
               UnknownUserActionText == other.UnknownUserActionText &&
               KnownUserActionText == other.KnownUserActionText &&
               Title == other.Title &&
               Description == other.Description;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(EMailSettingSubscriptionLocalization? other)
    {
        if (other is null) return;
        if (UnknownUserDescription != other.UnknownUserDescription)
        {
            UnknownUserDescription = other.UnknownUserDescription;
            OnPropertyChanged(nameof(UnknownUserDescription));
        }
        if (RegisteredUserDescription != other.RegisteredUserDescription)
        {
            RegisteredUserDescription = other.RegisteredUserDescription;
            OnPropertyChanged(nameof(RegisteredUserDescription));
        }
        if (UnregisteredUserDescription != other.UnregisteredUserDescription)
        {
            UnregisteredUserDescription = other.UnregisteredUserDescription;
            OnPropertyChanged(nameof(UnregisteredUserDescription));
        }
        if (UnknownUserActionText != other.UnknownUserActionText)
        {
            UnknownUserActionText = other.UnknownUserActionText;
            OnPropertyChanged(nameof(UnknownUserActionText));
        }
        if (KnownUserActionText != other.KnownUserActionText)
        {
            KnownUserActionText = other.KnownUserActionText;
            OnPropertyChanged(nameof(KnownUserActionText));
        }
        if (Title != other.Title)
        {
            Title = other.Title;
            OnPropertyChanged(nameof(Title));
        }
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
    }
}