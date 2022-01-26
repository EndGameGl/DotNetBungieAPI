namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class TagMetadataDefinition : IDeepEquatable<TagMetadataDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("items")]
    public List<Content.Models.TagMetadataItem> Items { get; set; }

    [JsonPropertyName("datatype")]
    public string Datatype { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("isRequired")]
    public bool IsRequired { get; set; }

    public bool DeepEquals(TagMetadataDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               Order == other.Order &&
               Items.DeepEqualsList(other.Items) &&
               Datatype == other.Datatype &&
               Name == other.Name &&
               IsRequired == other.IsRequired;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TagMetadataDefinition? other)
    {
        if (other is null) return;
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (Order != other.Order)
        {
            Order = other.Order;
            OnPropertyChanged(nameof(Order));
        }
        if (!Items.DeepEqualsList(other.Items))
        {
            Items = other.Items;
            OnPropertyChanged(nameof(Items));
        }
        if (Datatype != other.Datatype)
        {
            Datatype = other.Datatype;
            OnPropertyChanged(nameof(Datatype));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (IsRequired != other.IsRequired)
        {
            IsRequired = other.IsRequired;
            OnPropertyChanged(nameof(IsRequired));
        }
    }
}