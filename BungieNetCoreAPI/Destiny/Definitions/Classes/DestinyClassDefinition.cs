using BungieNetCoreAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Classes
{
    public class DestinyClassDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyClassType ClassType { get; }
        public ClassGenderedNames GenderedClassNames { get; }
        public Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedClassNamesByGender { get; }

        [JsonConstructor]
        private DestinyClassDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyClassType classType, ClassGenderedNames genderedClassNames,
            Dictionary<uint, string> genderedClassNamesByGenderHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
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
                    GenderedClassNamesByGender.Add(new DefinitionHashPointer<DestinyGenderDefinition>(item.Key, "DestinyGenderDefinition"), item.Value);
                }
            }
        }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }
    }
}
