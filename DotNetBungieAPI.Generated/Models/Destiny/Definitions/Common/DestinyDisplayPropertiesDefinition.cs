namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Common;

/// <summary>
///     Many Destiny*Definition contracts - the "first order" entities of Destiny that have their own tables in the Manifest Database - also have displayable information. This is the base class for that display information.
/// </summary>
public class DestinyDisplayPropertiesDefinition : IDeepEquatable<DestinyDisplayPropertiesDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
    /// <para />
    ///     But usually, it will be a small square image that you can use as... well, an icon.
    /// <para />
    ///     They are currently represented as 96px x 96px images.
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("iconSequences")]
    public List<Destiny.Definitions.Common.DestinyIconSequenceDefinition> IconSequences { get; set; }

    /// <summary>
    ///     If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.
    /// </summary>
    [JsonPropertyName("highResIcon")]
    public string HighResIcon { get; set; }

    [JsonPropertyName("hasIcon")]
    public bool HasIcon { get; set; }

    public bool DeepEquals(DestinyDisplayPropertiesDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               Name == other.Name &&
               Icon == other.Icon &&
               IconSequences.DeepEqualsList(other.IconSequences) &&
               HighResIcon == other.HighResIcon &&
               HasIcon == other.HasIcon;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyDisplayPropertiesDefinition? other)
    {
        if (other is null) return;
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (Icon != other.Icon)
        {
            Icon = other.Icon;
            OnPropertyChanged(nameof(Icon));
        }
        if (!IconSequences.DeepEqualsList(other.IconSequences))
        {
            IconSequences = other.IconSequences;
            OnPropertyChanged(nameof(IconSequences));
        }
        if (HighResIcon != other.HighResIcon)
        {
            HighResIcon = other.HighResIcon;
            OnPropertyChanged(nameof(HighResIcon));
        }
        if (HasIcon != other.HasIcon)
        {
            HasIcon = other.HasIcon;
            OnPropertyChanged(nameof(HasIcon));
        }
    }
}