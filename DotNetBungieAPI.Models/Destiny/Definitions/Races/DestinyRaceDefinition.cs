using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Genders;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Races;

/// <summary>
///     In Destiny, "Races" are really more like "Species". Sort of. I mean, are the Awoken a separate species from humans?
///     I'm not sure. But either way, they're defined here. You'll see Exo, Awoken, and Human as examples of these Species.
///     Players will choose one for their character.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyRaceDefinition)]
public sealed record DestinyRaceDefinition : IDestinyDefinition, IDisplayProperties, IDeepEquatable<DestinyRaceDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     An enumeration defining the existing, known Races/Species for player characters. This value will be the enum value
    ///     matching this definition.
    /// </summary>
    [JsonPropertyName("raceType")]
    public DestinyRace RaceType { get; init; }

    /// <summary>
    ///     A localized string referring to the singular form of the Race's name when referred to in gendered form. Keyed by
    ///     the DestinyGender.
    /// </summary>
    [JsonPropertyName("genderedRaceNames")]
    public ReadOnlyDictionary<string, string> GenderedRaceNames { get; init; } =
        ReadOnlyDictionaries<string, string>.Empty;

    [JsonPropertyName("genderedRaceNamesByGenderHash")]
    public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedRaceNamesByGender { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyGenderDefinition>, string>.Empty;

    public bool DeepEquals(DestinyRaceDefinition other)
    {
        return other != null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               RaceType == other.RaceType &&
               GenderedRaceNames.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.GenderedRaceNames) &&
               GenderedRaceNamesByGender.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(
                   other.GenderedRaceNamesByGender) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyRaceDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}