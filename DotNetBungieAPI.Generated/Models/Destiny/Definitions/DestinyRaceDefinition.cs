namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     In Destiny, "Races" are really more like "Species". Sort of. I mean, are the Awoken a separate species from humans? I'm not sure. But either way, they're defined here. You'll see Exo, Awoken, and Human as examples of these Species. Players will choose one for their character.
/// </summary>
public class DestinyRaceDefinition : IDeepEquatable<DestinyRaceDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     An enumeration defining the existing, known Races/Species for player characters. This value will be the enum value matching this definition.
    /// </summary>
    [JsonPropertyName("raceType")]
    public Destiny.DestinyRace RaceType { get; set; }

    /// <summary>
    ///     A localized string referring to the singular form of the Race's name when referred to in gendered form. Keyed by the DestinyGender.
    /// </summary>
    [JsonPropertyName("genderedRaceNames")]
    public Dictionary<Destiny.DestinyGender, string> GenderedRaceNames { get; set; }

    [JsonPropertyName("genderedRaceNamesByGenderHash")]
    public Dictionary<uint, string> GenderedRaceNamesByGenderHash { get; set; }

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

    public bool DeepEquals(DestinyRaceDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               RaceType == other.RaceType &&
               GenderedRaceNames.DeepEqualsDictionaryNaive(other.GenderedRaceNames) &&
               GenderedRaceNamesByGenderHash.DeepEqualsDictionaryNaive(other.GenderedRaceNamesByGenderHash) &&
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

    public void Update(DestinyRaceDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (RaceType != other.RaceType)
        {
            RaceType = other.RaceType;
            OnPropertyChanged(nameof(RaceType));
        }
        if (!GenderedRaceNames.DeepEqualsDictionaryNaive(other.GenderedRaceNames))
        {
            GenderedRaceNames = other.GenderedRaceNames;
            OnPropertyChanged(nameof(GenderedRaceNames));
        }
        if (!GenderedRaceNamesByGenderHash.DeepEqualsDictionaryNaive(other.GenderedRaceNamesByGenderHash))
        {
            GenderedRaceNamesByGenderHash = other.GenderedRaceNamesByGenderHash;
            OnPropertyChanged(nameof(GenderedRaceNamesByGenderHash));
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