namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Animations;

public class DestinyAnimationReference : IDeepEquatable<DestinyAnimationReference>
{
    [JsonPropertyName("animName")]
    public string AnimName { get; set; }

    [JsonPropertyName("animIdentifier")]
    public string AnimIdentifier { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    public bool DeepEquals(DestinyAnimationReference? other)
    {
        return other is not null &&
               AnimName == other.AnimName &&
               AnimIdentifier == other.AnimIdentifier &&
               Path == other.Path;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyAnimationReference? other)
    {
        if (other is null) return;
        if (AnimName != other.AnimName)
        {
            AnimName = other.AnimName;
            OnPropertyChanged(nameof(AnimName));
        }
        if (AnimIdentifier != other.AnimIdentifier)
        {
            AnimIdentifier = other.AnimIdentifier;
            OnPropertyChanged(nameof(AnimIdentifier));
        }
        if (Path != other.Path)
        {
            Path = other.Path;
            OnPropertyChanged(nameof(Path));
        }
    }
}