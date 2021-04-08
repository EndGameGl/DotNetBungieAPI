using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Genders;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Races
{
    [DestinyDefinition(DefinitionsEnum.DestinyRaceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyRaceDefinition : IDestinyDefinition, IDeepEquatable<DestinyRaceDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("raceType")]
        public DestinyRace RaceType { get; init; }
        [JsonPropertyName("genderedRaceNames")]
        public ReadOnlyDictionary<DestinyGender, string> GenderedRaceNames { get; init; } = Defaults.EmptyReadOnlyDictionary<DestinyGender, string>();
        [JsonPropertyName("genderedRaceNamesByGenderHash")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedRaceNamesByGender { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }
        public bool DeepEquals(DestinyRaceDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   RaceType == other.RaceType &&
                   GenderedRaceNames.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.GenderedRaceNames) &&
                   GenderedRaceNamesByGender.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.GenderedRaceNamesByGender) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var race in GenderedRaceNamesByGender.Keys)
            {
                race.TryMapValue();
            }
        }
    }
}
