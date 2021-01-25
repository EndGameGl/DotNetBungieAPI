using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Races
{
    [DestinyDefinition(name: "DestinyRaceDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyRaceDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyRaceType RaceType { get; }
        public RaceGenderedNames GenderedRaceNames { get; }
        public Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedRaceNamesByGender { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyRaceDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyRaceType raceType, RaceGenderedNames genderedRaceNames,
            Dictionary<uint, string> genderedRaceNamesByGenderHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            RaceType = raceType;
            GenderedRaceNames = genderedRaceNames;
            if (genderedRaceNamesByGenderHash == null)
                GenderedRaceNamesByGender = new Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
            else
            {
                GenderedRaceNamesByGender = new Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
                foreach (var item in genderedRaceNamesByGenderHash)
                {
                    GenderedRaceNamesByGender.Add(new DefinitionHashPointer<DestinyGenderDefinition>(item.Key, DefinitionsEnum.DestinyGenderDefinition), item.Value);
                }
            }
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }
    }
}
