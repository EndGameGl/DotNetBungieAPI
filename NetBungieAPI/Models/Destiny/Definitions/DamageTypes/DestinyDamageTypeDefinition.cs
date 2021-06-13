using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.DamageTypes
{
    /// <summary>
    /// All damage types that are possible in the game are defined here, along with localized info and icons as needed.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyDamageTypeDefinition)]
    public sealed record DestinyDamageTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyDamageTypeDefinition>
    {
        /// <summary>
        /// The description of the damage type, icon etc...
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        /// We have an enumeration for damage types for quick reference. This is the current definition's damage type enum value.
        /// </summary>
        [JsonPropertyName("enumValue")]
        public DamageType EnumValue { get; init; }

        /// <summary>
        /// If TRUE, the game shows this damage type's icon. Otherwise, it doesn't. Whether you show it or not is up to you.
        /// </summary>
        [JsonPropertyName("showIcon")]
        public bool ShowIcon { get; init; }

        /// <summary>
        /// A variant of the icon that is transparent and colorless.
        /// </summary>
        [JsonPropertyName("transparentIconPath")]
        public string TransparentIconPath { get; init; }

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

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