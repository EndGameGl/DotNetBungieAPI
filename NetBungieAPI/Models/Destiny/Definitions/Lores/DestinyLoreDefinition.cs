using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;

namespace NetBungieAPI.Models.Destiny.Definitions.Lores
{
    /// <summary>
    ///     These are definitions for in-game "Lore," meant to be narrative enhancements of the game experience.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyLoreDefinition)]
    public sealed record DestinyLoreDefinition : IDestinyDefinition, IDeepEquatable<DestinyLoreDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonPropertyName("subtitle")] public string Subtitle { get; init; }

        public bool DeepEquals(DestinyLoreDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Subtitle == other.Subtitle &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }
    }
}