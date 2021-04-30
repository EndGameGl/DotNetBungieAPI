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
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("enumValue")]
        public DamageType EnumValue { get; init; }
        [JsonPropertyName("showIcon")]
        public bool ShowIcon { get; init; }
        [JsonPropertyName("transparentIconPath")]
        public string TransparentIconPath { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

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
