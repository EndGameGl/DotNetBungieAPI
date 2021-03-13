using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Races
{
    [DestinyDefinition(DefinitionsEnum.DestinyRaceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyRaceDefinition : IDestinyDefinition, IDeepEquatable<DestinyRaceDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyRaceType RaceType { get; }
        public RaceGenderedNames GenderedRaceNames { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedRaceNamesByGender { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRaceDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyRaceType raceType, RaceGenderedNames genderedRaceNames,
            Dictionary<uint, string> genderedRaceNamesByGenderHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            RaceType = raceType;
            GenderedRaceNames = genderedRaceNames;
            GenderedRaceNamesByGender = genderedRaceNamesByGenderHash.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyGenderDefinition, string>(DefinitionsEnum.DestinyGenderDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }
        public bool DeepEquals(DestinyRaceDefinition other)
        {
            return other != null&&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   RaceType == other.RaceType &&
                   GenderedRaceNames.DeepEquals(other.GenderedRaceNames) &&
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
