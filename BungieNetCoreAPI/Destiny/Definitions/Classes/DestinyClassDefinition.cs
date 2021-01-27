using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Classes
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyClassDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyClassDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyClassType ClassType { get; }
        public ClassGenderedNames GenderedClassNames { get; }
        public Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedClassNamesByGender { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyClassDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyClassType classType, ClassGenderedNames genderedClassNames,
            Dictionary<uint, string> genderedClassNamesByGenderHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            ClassType = classType;
            GenderedClassNames = genderedClassNames;
            if (genderedClassNamesByGenderHash == null)
                GenderedClassNamesByGender = new Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
            else
            {
                GenderedClassNamesByGender = new Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
                foreach (var item in genderedClassNamesByGenderHash)
                {
                    GenderedClassNamesByGender.Add(new DefinitionHashPointer<DestinyGenderDefinition>(item.Key, DefinitionsEnum.DestinyGenderDefinition), item.Value);
                }
            }

        }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }
    }
}
