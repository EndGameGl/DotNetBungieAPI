using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Destinations
{
    /// <summary>
    /// Basic identifying data about the bubble.
    /// </summary>
    public sealed record DestinyBubbleDefinition : IDeepEquatable<DestinyBubbleDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }

        public bool DeepEquals(DestinyBubbleDefinition other)
        {
            return other != null &&
                DisplayProperties.DeepEquals(other.DisplayProperties) &&
                Hash == other.Hash;
        }
    }
}
