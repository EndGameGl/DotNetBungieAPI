namespace DotNetBungieAPI.Generated.Models.User;

/// <summary>
///     Represents a data-driven view for Email settings. Web/Mobile UI can use this data to show new EMail settings consistently without further manual work.
/// </summary>
public class EmailViewDefinition : IDeepEquatable<EmailViewDefinition>
{
    /// <summary>
    ///     The identifier for this view.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     The ordered list of settings to show in this view.
    /// </summary>
    [JsonPropertyName("viewSettings")]
    public List<User.EmailViewDefinitionSetting> ViewSettings { get; set; }

    public bool DeepEquals(EmailViewDefinition? other)
    {
        return other is not null &&
               Name == other.Name &&
               ViewSettings.DeepEqualsList(other.ViewSettings);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(EmailViewDefinition? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (!ViewSettings.DeepEqualsList(other.ViewSettings))
        {
            ViewSettings = other.ViewSettings;
            OnPropertyChanged(nameof(ViewSettings));
        }
    }
}