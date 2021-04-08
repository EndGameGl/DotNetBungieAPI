using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers
{
    /// <summary>
    /// Modifiers - in Destiny 1, these were referred to as "Skulls" - are changes that can be applied to an Activity.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyActivityModifierDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyActivityModifierDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityModifierDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

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
        public bool DeepEquals(DestinyActivityModifierDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
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
