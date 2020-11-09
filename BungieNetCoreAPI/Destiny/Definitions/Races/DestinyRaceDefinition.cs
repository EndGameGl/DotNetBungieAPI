using BungieNetCoreAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Races
{
    public class DestinyRaceDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyRaceType RaceType { get; }
        public RaceGenderedNames GenderedRaceNames { get; }
        public Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedRaceNamesByGender { get; }

        [JsonConstructor]
        private DestinyRaceDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyRaceType raceType, RaceGenderedNames genderedRaceNames,
            Dictionary<uint, string> genderedRaceNamesByGenderHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
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
                    GenderedRaceNamesByGender.Add(new DefinitionHashPointer<DestinyGenderDefinition>(item.Key, "DestinyGenderDefinition"), item.Value);
                }
            }
        }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }
    }
}
