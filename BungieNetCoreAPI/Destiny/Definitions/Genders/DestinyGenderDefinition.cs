using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Genders
{
    public class DestinyGenderDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyGenderTypes GenderType { get; }

        [JsonConstructor]
        private DestinyGenderDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyGenderTypes genderType, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            GenderType = genderType;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
