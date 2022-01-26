namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypePropertySection : IDeepEquatable<ContentTypePropertySection>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("readableName")]
    public string ReadableName { get; set; }

    [JsonPropertyName("collapsed")]
    public bool Collapsed { get; set; }

    public bool DeepEquals(ContentTypePropertySection? other)
    {
        return other is not null &&
               Name == other.Name &&
               ReadableName == other.ReadableName &&
               Collapsed == other.Collapsed;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ContentTypePropertySection? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (ReadableName != other.ReadableName)
        {
            ReadableName = other.ReadableName;
            OnPropertyChanged(nameof(ReadableName));
        }
        if (Collapsed != other.Collapsed)
        {
            Collapsed = other.Collapsed;
            OnPropertyChanged(nameof(Collapsed));
        }
    }
}