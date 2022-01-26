namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

public class GearAssetDataBaseDefinition : IDeepEquatable<GearAssetDataBaseDefinition>
{
    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    public bool DeepEquals(GearAssetDataBaseDefinition? other)
    {
        return other is not null &&
               Version == other.Version &&
               Path == other.Path;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GearAssetDataBaseDefinition? other)
    {
        if (other is null) return;
        if (Version != other.Version)
        {
            Version = other.Version;
            OnPropertyChanged(nameof(Version));
        }
        if (Path != other.Path)
        {
            Path = other.Path;
            OnPropertyChanged(nameof(Path));
        }
    }
}