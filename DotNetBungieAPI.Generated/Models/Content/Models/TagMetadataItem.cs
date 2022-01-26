namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class TagMetadataItem : IDeepEquatable<TagMetadataItem>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("groups")]
    public List<string> Groups { get; set; }

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    public bool DeepEquals(TagMetadataItem? other)
    {
        return other is not null &&
               Description == other.Description &&
               TagText == other.TagText &&
               Groups.DeepEqualsListNaive(other.Groups) &&
               IsDefault == other.IsDefault &&
               Name == other.Name;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TagMetadataItem? other)
    {
        if (other is null) return;
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (TagText != other.TagText)
        {
            TagText = other.TagText;
            OnPropertyChanged(nameof(TagText));
        }
        if (!Groups.DeepEqualsListNaive(other.Groups))
        {
            Groups = other.Groups;
            OnPropertyChanged(nameof(Groups));
        }
        if (IsDefault != other.IsDefault)
        {
            IsDefault = other.IsDefault;
            OnPropertyChanged(nameof(IsDefault));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
    }
}