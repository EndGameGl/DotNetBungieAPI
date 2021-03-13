using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Genders
{
    [DestinyDefinition(DefinitionsEnum.DestinyGenderDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyGenderDefinition : IDestinyDefinition, IDeepEquatable<DestinyGenderDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyGenderTypes GenderType { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyGenderDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyGenderTypes genderType, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            GenderType = genderType;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyGenderDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   GenderType == other.GenderType &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            return;
        }
    }
}
