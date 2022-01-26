namespace DotNetBungieAPI.Generated.Models.Content;

public class ContentRepresentation : IDeepEquatable<ContentRepresentation>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("validationString")]
    public string ValidationString { get; set; }

    public bool DeepEquals(ContentRepresentation? other)
    {
        return other is not null &&
               Name == other.Name &&
               Path == other.Path &&
               ValidationString == other.ValidationString;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ContentRepresentation? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (Path != other.Path)
        {
            Path = other.Path;
            OnPropertyChanged(nameof(Path));
        }
        if (ValidationString != other.ValidationString)
        {
            ValidationString = other.ValidationString;
            OnPropertyChanged(nameof(ValidationString));
        }
    }
}