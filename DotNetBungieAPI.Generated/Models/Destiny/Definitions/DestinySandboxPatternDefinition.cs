namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinySandboxPatternDefinition : IDeepEquatable<DestinySandboxPatternDefinition>
{
    [JsonPropertyName("patternHash")]
    public uint PatternHash { get; set; }

    [JsonPropertyName("patternGlobalTagIdHash")]
    public uint PatternGlobalTagIdHash { get; set; }

    [JsonPropertyName("weaponContentGroupHash")]
    public uint WeaponContentGroupHash { get; set; }

    [JsonPropertyName("weaponTranslationGroupHash")]
    public uint WeaponTranslationGroupHash { get; set; }

    [JsonPropertyName("weaponTypeHash")]
    public uint? WeaponTypeHash { get; set; }

    [JsonPropertyName("weaponType")]
    public Destiny.DestinyItemSubType WeaponType { get; set; }

    [JsonPropertyName("filters")]
    public List<Destiny.Definitions.DestinyArrangementRegionFilterDefinition> Filters { get; set; }

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

    public bool DeepEquals(DestinySandboxPatternDefinition? other)
    {
        return other is not null &&
               PatternHash == other.PatternHash &&
               PatternGlobalTagIdHash == other.PatternGlobalTagIdHash &&
               WeaponContentGroupHash == other.WeaponContentGroupHash &&
               WeaponTranslationGroupHash == other.WeaponTranslationGroupHash &&
               WeaponTypeHash == other.WeaponTypeHash &&
               WeaponType == other.WeaponType &&
               Filters.DeepEqualsList(other.Filters) &&
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

    public void Update(DestinySandboxPatternDefinition? other)
    {
        if (other is null) return;
        if (PatternHash != other.PatternHash)
        {
            PatternHash = other.PatternHash;
            OnPropertyChanged(nameof(PatternHash));
        }
        if (PatternGlobalTagIdHash != other.PatternGlobalTagIdHash)
        {
            PatternGlobalTagIdHash = other.PatternGlobalTagIdHash;
            OnPropertyChanged(nameof(PatternGlobalTagIdHash));
        }
        if (WeaponContentGroupHash != other.WeaponContentGroupHash)
        {
            WeaponContentGroupHash = other.WeaponContentGroupHash;
            OnPropertyChanged(nameof(WeaponContentGroupHash));
        }
        if (WeaponTranslationGroupHash != other.WeaponTranslationGroupHash)
        {
            WeaponTranslationGroupHash = other.WeaponTranslationGroupHash;
            OnPropertyChanged(nameof(WeaponTranslationGroupHash));
        }
        if (WeaponTypeHash != other.WeaponTypeHash)
        {
            WeaponTypeHash = other.WeaponTypeHash;
            OnPropertyChanged(nameof(WeaponTypeHash));
        }
        if (WeaponType != other.WeaponType)
        {
            WeaponType = other.WeaponType;
            OnPropertyChanged(nameof(WeaponType));
        }
        if (!Filters.DeepEqualsList(other.Filters))
        {
            Filters = other.Filters;
            OnPropertyChanged(nameof(Filters));
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