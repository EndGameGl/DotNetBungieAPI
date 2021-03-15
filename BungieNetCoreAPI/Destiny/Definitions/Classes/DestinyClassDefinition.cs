using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Classes
{
    [DestinyDefinition(DefinitionsEnum.DestinyClassDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyClassDefinition : IDestinyDefinition, IDeepEquatable<DestinyClassDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyClassType ClassType { get; }
        public ClassGenderedNames GenderedClassNames { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> GenderedClassNamesByGender { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyClassDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyClassType classType, ClassGenderedNames genderedClassNames,
            Dictionary<uint, string> genderedClassNamesByGenderHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            ClassType = classType;
            GenderedClassNames = genderedClassNames;
            GenderedClassNamesByGender = genderedClassNamesByGenderHash.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyGenderDefinition, string>(DefinitionsEnum.DestinyGenderDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}: {DisplayProperties.Name}";
        }

        public bool DeepEquals(DestinyClassDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   ClassType == other.ClassType &&
                   GenderedClassNames.DeepEquals(other.GenderedClassNames) &&
                   GenderedClassNamesByGender.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.GenderedClassNamesByGender) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var name in GenderedClassNamesByGender)
            {
                name.Key.TryMapValue();
            }
        }
    }
}
