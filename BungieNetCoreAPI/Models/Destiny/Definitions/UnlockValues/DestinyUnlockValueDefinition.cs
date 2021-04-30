using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;

namespace NetBungieAPI.Models.Destiny.Definitions.UnlockValues
{
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockValueDefinition)]
    public sealed record DestinyUnlockValueDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockValueDefinition>
    {
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public bool DeepEquals(DestinyUnlockValueDefinition other)
        {
            return other != null && 
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
