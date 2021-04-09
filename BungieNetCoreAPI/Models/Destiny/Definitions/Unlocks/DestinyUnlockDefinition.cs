using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Unlocks
{
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyUnlockDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        [JsonPropertyName("scope")]
        public int Scope { get; init; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        [JsonPropertyName("unlockType")]
        public int UnlockType { get; init; }
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
        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyUnlockDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Scope == other.Scope &&
                   UnlockType == other.UnlockType &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
