using System.Text.Json.Serialization;
using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.BreakerTypes
{
    [DestinyDefinition(DefinitionsEnum.DestinyBreakerTypeDefinition)]
    public sealed record DestinyBreakerTypeDefinition : IDestinyDefinition, IDeepEquatable<DestinyBreakerTypeDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonPropertyName("unlockHash")] public uint UnlockHash { get; init; }

        /// <summary>
        ///     We have an enumeration for Breaker types for quick reference. This is the current definition's breaker type enum
        ///     value.
        /// </summary>
        [JsonPropertyName("enumValue")]
        public DestinyBreakerType EnumValue { get; init; }

        public bool DeepEquals(DestinyBreakerTypeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   UnlockHash == other.UnlockHash &&
                   EnumValue == other.EnumValue &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyBreakerTypeDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

        [JsonPropertyName("hash")] public uint Hash { get; init; }

        [JsonPropertyName("index")] public int Index { get; init; }

        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public void SetPointerLocales(BungieLocales locale)
        {
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}