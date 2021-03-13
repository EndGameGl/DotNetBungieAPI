using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.DamageTypes
{
    /// <summary>
    /// All damage types that are possible in the game are defined here, along with localized info and icons as needed.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyDamageTypeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyDamageTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyDamageTypeDefinition>
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
        internal DestinyDamageTypeDefinition(DestinyDefinitionDisplayProperties displayProperties, DamageType enumValue, bool showIcon, string transparentIconPath,
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

        public bool DeepEquals(DestinyDamageTypeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   EnumValue == other.EnumValue &&
                   ShowIcon == other.ShowIcon &&
                   TransparentIconPath == other.TransparentIconPath &&
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
