namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentPreview : IDeepEquatable<ContentPreview>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("itemInSet")]
    public bool ItemInSet { get; set; }

    [JsonPropertyName("setTag")]
    public string SetTag { get; set; }

    [JsonPropertyName("setNesting")]
    public int SetNesting { get; set; }

    [JsonPropertyName("useSetId")]
    public int UseSetId { get; set; }

    public bool DeepEquals(ContentPreview? other)
    {
        return other is not null &&
               Name == other.Name &&
               Path == other.Path &&
               ItemInSet == other.ItemInSet &&
               SetTag == other.SetTag &&
               SetNesting == other.SetNesting &&
               UseSetId == other.UseSetId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(ContentPreview? other)
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
        if (ItemInSet != other.ItemInSet)
        {
            ItemInSet = other.ItemInSet;
            OnPropertyChanged(nameof(ItemInSet));
        }
        if (SetTag != other.SetTag)
        {
            SetTag = other.SetTag;
            OnPropertyChanged(nameof(SetTag));
        }
        if (SetNesting != other.SetNesting)
        {
            SetNesting = other.SetNesting;
            OnPropertyChanged(nameof(SetNesting));
        }
        if (UseSetId != other.UseSetId)
        {
            UseSetId = other.UseSetId;
            OnPropertyChanged(nameof(UseSetId));
        }
    }
}