namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Stat Groups (DestinyStatGroupDefinition) has the ability to override the localized text associated with stats that are to be shown on the items with which they are associated.
/// <para />
///     This defines a specific overridden stat. You could theoretically check these before rendering your stat UI, and for each stat that has an override show these displayProperties instead of those on the DestinyStatDefinition.
/// <para />
///     Or you could be like us, and skip that for now because the game has yet to actually use this feature. But know that it's here, waiting for a resilliant young designer to take up the mantle and make us all look foolish by showing the wrong name for stats.
/// <para />
///     Note that, if this gets used, the override will apply only to items using the overriding Stat Group. Other items will still show the default stat's name/description.
/// </summary>
public class DestinyStatOverrideDefinition : IDeepEquatable<DestinyStatOverrideDefinition>
{
    /// <summary>
    ///     The hash identifier of the stat whose display properties are being overridden.
    /// </summary>
    [JsonPropertyName("statHash")]
    public uint StatHash { get; set; }

    /// <summary>
    ///     The display properties to show instead of the base DestinyStatDefinition display properties.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    public bool DeepEquals(DestinyStatOverrideDefinition? other)
    {
        return other is not null &&
               StatHash == other.StatHash &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyStatOverrideDefinition? other)
    {
        if (other is null) return;
        if (StatHash != other.StatHash)
        {
            StatHash = other.StatHash;
            OnPropertyChanged(nameof(StatHash));
        }
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
    }
}