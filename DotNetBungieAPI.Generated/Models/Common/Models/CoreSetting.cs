namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSetting : IDeepEquatable<CoreSetting>
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("imagePath")]
    public string ImagePath { get; set; }

    [JsonPropertyName("childSettings")]
    public List<Common.Models.CoreSetting> ChildSettings { get; set; }

    public bool DeepEquals(CoreSetting? other)
    {
        return other is not null &&
               Identifier == other.Identifier &&
               IsDefault == other.IsDefault &&
               DisplayName == other.DisplayName &&
               Summary == other.Summary &&
               ImagePath == other.ImagePath &&
               ChildSettings.DeepEqualsList(other.ChildSettings);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(CoreSetting? other)
    {
        if (other is null) return;
        if (Identifier != other.Identifier)
        {
            Identifier = other.Identifier;
            OnPropertyChanged(nameof(Identifier));
        }
        if (IsDefault != other.IsDefault)
        {
            IsDefault = other.IsDefault;
            OnPropertyChanged(nameof(IsDefault));
        }
        if (DisplayName != other.DisplayName)
        {
            DisplayName = other.DisplayName;
            OnPropertyChanged(nameof(DisplayName));
        }
        if (Summary != other.Summary)
        {
            Summary = other.Summary;
            OnPropertyChanged(nameof(Summary));
        }
        if (ImagePath != other.ImagePath)
        {
            ImagePath = other.ImagePath;
            OnPropertyChanged(nameof(ImagePath));
        }
        if (!ChildSettings.DeepEqualsList(other.ChildSettings))
        {
            ChildSettings = other.ChildSettings;
            OnPropertyChanged(nameof(ChildSettings));
        }
    }
}