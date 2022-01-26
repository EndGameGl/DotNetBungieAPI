namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     An individual Destiny Entity returned from the entity search.
/// </summary>
public class DestinyEntitySearchResultItem : IDeepEquatable<DestinyEntitySearchResultItem>
{
    /// <summary>
    ///     The hash identifier of the entity. You will use this to look up the DestinyDefinition relevant for the entity found.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The type of entity, returned as a string matching the DestinyDefinition's contract class name. You'll have to have your own mapping from class names to actually looking up those definitions in the manifest databases.
    /// </summary>
    [JsonPropertyName("entityType")]
    public string EntityType { get; set; }

    /// <summary>
    ///     Basic display properties on the entity, so you don't have to look up the definition to show basic results for the item.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The ranking value for sorting that we calculated using our relevance formula. This will hopefully get better with time and iteration.
    /// </summary>
    [JsonPropertyName("weight")]
    public double Weight { get; set; }

    public bool DeepEquals(DestinyEntitySearchResultItem? other)
    {
        return other is not null &&
               Hash == other.Hash &&
               EntityType == other.EntityType &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Weight == other.Weight;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyEntitySearchResultItem? other)
    {
        if (other is null) return;
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (EntityType != other.EntityType)
        {
            EntityType = other.EntityType;
            OnPropertyChanged(nameof(EntityType));
        }
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (Weight != other.Weight)
        {
            Weight = other.Weight;
            OnPropertyChanged(nameof(Weight));
        }
    }
}