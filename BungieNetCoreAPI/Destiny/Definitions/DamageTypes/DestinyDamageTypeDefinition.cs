using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.DamageTypes
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyDamageTypeDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyDamageTypeDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DamageType EnumValue { get; }
        public bool ShowIcon { get; }
        public string TransparentIconPath { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyDamageTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, DamageType enumValue, bool showIcon, string transparentIconPath,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            EnumValue = enumValue;
            ShowIcon = showIcon;
            TransparentIconPath = transparentIconPath;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
