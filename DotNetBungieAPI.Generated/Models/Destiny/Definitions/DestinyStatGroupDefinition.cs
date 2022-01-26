namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     When an inventory item (DestinyInventoryItemDefinition) has Stats (such as Attack Power), the item will refer to a Stat Group. This definition enumerates the properties used to transform the item's "Investment" stats into "Display" stats.
/// <para />
///     See DestinyStatDefinition's documentation for information about the transformation of Stats, and the meaning of an Investment vs. a Display stat.
/// <para />
///     If you don't want to do these calculations on your own, fear not: pulling live data from the BNet endpoints will return display stat values pre-computed and ready for you to use. I highly recommend this approach, saves a lot of time and also accounts for certain stat modifiers that can't easily be accounted for without live data (such as stat modifiers on Talent Grids and Socket Plugs)
/// </summary>
public class DestinyStatGroupDefinition : IDeepEquatable<DestinyStatGroupDefinition>
{
    /// <summary>
    ///     The maximum possible value that any stat in this group can be transformed into.
    /// <para />
    ///     This is used by stats that *don't* have scaledStats entries below, but that still need to be displayed as a progress bar, in which case this is used as the upper bound for said progress bar. (the lower bound is always 0)
    /// </summary>
    [JsonPropertyName("maximumValue")]
    public int MaximumValue { get; set; }

    /// <summary>
    ///     This apparently indicates the position of the stats in the UI? I've returned it in case anyone can use it, but it's not of any use to us on BNet. Something's being lost in translation with this value.
    /// </summary>
    [JsonPropertyName("uiPosition")]
    public int UiPosition { get; set; }

    /// <summary>
    ///     Any stat that requires scaling to be transformed from an "Investment" stat to a "Display" stat will have an entry in this list. For more information on what those types of stats mean and the transformation process, see DestinyStatDefinition.
    /// <para />
    ///     In retrospect, I wouldn't mind if this was a dictionary keyed by the stat hash instead. But I'm going to leave it be because [[After Apple Picking]].
    /// </summary>
    [JsonPropertyName("scaledStats")]
    public List<Destiny.Definitions.DestinyStatDisplayDefinition> ScaledStats { get; set; }

    /// <summary>
    ///     The game has the ability to override, based on the stat group, what the localized text is that is displayed for Stats being shown on the item.
    /// <para />
    ///     Mercifully, no Stat Groups use this feature currently. If they start using them, we'll all need to start using them (and those of you who are more prudent than I am can go ahead and start pre-checking for this.)
    /// </summary>
    [JsonPropertyName("overrides")]
    public Dictionary<uint, Destiny.Definitions.DestinyStatOverrideDefinition> Overrides { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyStatGroupDefinition? other)
    {
        return other is not null &&
               MaximumValue == other.MaximumValue &&
               UiPosition == other.UiPosition &&
               ScaledStats.DeepEqualsList(other.ScaledStats) &&
               Overrides.DeepEqualsDictionary(other.Overrides) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyStatGroupDefinition? other)
    {
        if (other is null) return;
        if (MaximumValue != other.MaximumValue)
        {
            MaximumValue = other.MaximumValue;
            OnPropertyChanged(nameof(MaximumValue));
        }
        if (UiPosition != other.UiPosition)
        {
            UiPosition = other.UiPosition;
            OnPropertyChanged(nameof(UiPosition));
        }
        if (!ScaledStats.DeepEqualsList(other.ScaledStats))
        {
            ScaledStats = other.ScaledStats;
            OnPropertyChanged(nameof(ScaledStats));
        }
        if (!Overrides.DeepEqualsDictionary(other.Overrides))
        {
            Overrides = other.Overrides;
            OnPropertyChanged(nameof(Overrides));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}