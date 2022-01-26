namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyVendorDisplayPropertiesDefinition : IDeepEquatable<DestinyVendorDisplayPropertiesDefinition>
{
    /// <summary>
    ///     I regret calling this a "large icon". It's more like a medium-sized image with a picture of the vendor's mug on it, trying their best to look cool. Not what one would call an icon.
    /// </summary>
    [JsonPropertyName("largeIcon")]
    public string LargeIcon { get; set; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    /// <summary>
    ///     If we replaced the icon with something more glitzy, this is the original icon that the vendor had according to the game's content. It may be more lame and/or have less razzle-dazzle. But who am I to tell you which icon to use.
    /// </summary>
    [JsonPropertyName("originalIcon")]
    public string OriginalIcon { get; set; }

    /// <summary>
    ///     Vendors, in addition to expected display property data, may also show some "common requirements" as statically defined definition data. This might be when a vendor accepts a single type of currency, or when the currency is unique to the vendor and the designers wanted to show that currency when you interact with the vendor.
    /// </summary>
    [JsonPropertyName("requirementsDisplay")]
    public List<Destiny.Definitions.DestinyVendorRequirementDisplayEntryDefinition> RequirementsDisplay { get; set; }

    /// <summary>
    ///     This is the icon used in parts of the game UI such as the vendor's waypoint.
    /// </summary>
    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; set; }

    /// <summary>
    ///     This is the icon used in the map overview, when the vendor is located on the map.
    /// </summary>
    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; set; }

    /// <summary>
    ///     This is apparently the "Watermark". I am not certain offhand where this is actually used in the Game UI, but some people may find it useful.
    /// </summary>
    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; set; }

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

    public bool DeepEquals(DestinyVendorDisplayPropertiesDefinition? other)
    {
        return other is not null &&
               LargeIcon == other.LargeIcon &&
               Subtitle == other.Subtitle &&
               OriginalIcon == other.OriginalIcon &&
               RequirementsDisplay.DeepEqualsList(other.RequirementsDisplay) &&
               SmallTransparentIcon == other.SmallTransparentIcon &&
               MapIcon == other.MapIcon &&
               LargeTransparentIcon == other.LargeTransparentIcon &&
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

    public void Update(DestinyVendorDisplayPropertiesDefinition? other)
    {
        if (other is null) return;
        if (LargeIcon != other.LargeIcon)
        {
            LargeIcon = other.LargeIcon;
            OnPropertyChanged(nameof(LargeIcon));
        }
        if (Subtitle != other.Subtitle)
        {
            Subtitle = other.Subtitle;
            OnPropertyChanged(nameof(Subtitle));
        }
        if (OriginalIcon != other.OriginalIcon)
        {
            OriginalIcon = other.OriginalIcon;
            OnPropertyChanged(nameof(OriginalIcon));
        }
        if (!RequirementsDisplay.DeepEqualsList(other.RequirementsDisplay))
        {
            RequirementsDisplay = other.RequirementsDisplay;
            OnPropertyChanged(nameof(RequirementsDisplay));
        }
        if (SmallTransparentIcon != other.SmallTransparentIcon)
        {
            SmallTransparentIcon = other.SmallTransparentIcon;
            OnPropertyChanged(nameof(SmallTransparentIcon));
        }
        if (MapIcon != other.MapIcon)
        {
            MapIcon = other.MapIcon;
            OnPropertyChanged(nameof(MapIcon));
        }
        if (LargeTransparentIcon != other.LargeTransparentIcon)
        {
            LargeTransparentIcon = other.LargeTransparentIcon;
            OnPropertyChanged(nameof(LargeTransparentIcon));
        }
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