namespace DotNetBungieAPI.Generated.Models.Config;

public class GroupTheme : IDeepEquatable<GroupTheme>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("folder")]
    public string Folder { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    public bool DeepEquals(GroupTheme? other)
    {
        return other is not null &&
               Name == other.Name &&
               Folder == other.Folder &&
               Description == other.Description;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupTheme? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (Folder != other.Folder)
        {
            Folder = other.Folder;
            OnPropertyChanged(nameof(Folder));
        }
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
    }
}