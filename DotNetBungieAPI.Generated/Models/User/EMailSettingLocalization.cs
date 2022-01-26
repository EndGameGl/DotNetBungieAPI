namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Localized text relevant to a given EMail setting in a given localization.
/// </summary>
public class EMailSettingLocalization : IDeepEquatable<EMailSettingLocalization>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    public bool DeepEquals(EMailSettingLocalization? other)
    {
        return other is not null &&
               Title == other.Title &&
               Description == other.Description;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(EMailSettingLocalization? other)
    {
        if (other is null) return;
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