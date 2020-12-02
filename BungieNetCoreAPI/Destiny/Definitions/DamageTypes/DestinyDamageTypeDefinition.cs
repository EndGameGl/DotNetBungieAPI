using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.DamageTypes
{
    [DestinyDefinition("DestinyDamageTypeDefinition")]
    public class DestinyDamageTypeDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DestinyDamageTypes EnumValue { get; }
        public bool ShowIcon { get; }
        public string TransparentIconPath { get; }

        [JsonConstructor]
        private DestinyDamageTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, DestinyDamageTypes enumValue, bool showIcon, string transparentIconPath,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            EnumValue = enumValue;
            ShowIcon = showIcon;
            TransparentIconPath = transparentIconPath;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
