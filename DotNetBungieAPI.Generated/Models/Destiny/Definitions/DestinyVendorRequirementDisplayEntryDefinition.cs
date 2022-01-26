namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The localized properties of the requirementsDisplay, allowing information about the requirement or item being featured to be seen.
/// </summary>
public class DestinyVendorRequirementDisplayEntryDefinition : IDeepEquatable<DestinyVendorRequirementDisplayEntryDefinition>
{
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    public bool DeepEquals(DestinyVendorRequirementDisplayEntryDefinition? other)
    {
        return other is not null &&
               Icon == other.Icon &&
               Name == other.Name &&
               Source == other.Source &&
               Type == other.Type;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyVendorRequirementDisplayEntryDefinition? other)
    {
        if (other is null) return;
        if (Icon != other.Icon)
        {
            Icon = other.Icon;
            OnPropertyChanged(nameof(Icon));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (Source != other.Source)
        {
            Source = other.Source;
            OnPropertyChanged(nameof(Source));
        }
        if (Type != other.Type)
        {
            Type = other.Type;
            OnPropertyChanged(nameof(Type));
        }
    }
}