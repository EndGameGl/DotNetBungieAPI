using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SandboxPerks
{
    [DestinyDefinition("DestinySandboxPerkDefinition")]
    public class DestinySandboxPerkDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public int DamageType { get; }
        public bool IsDisplayable { get; }

        [JsonConstructor]
        private DestinySandboxPerkDefinition(DestinyDefinitionDisplayProperties displayProperties, int damageType, bool isDisplayable,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            DamageType = damageType;
            IsDisplayable = isDisplayable;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
