using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Destinations
{
    /// <summary>
    /// Basic identifying data about the bubble. Combine with DestinyDestinationBubbleSettingDefinition - see DestinyDestinationDefinition.bubbleSettings for more information.
    /// </summary>
    public sealed record DestinyBubbleDefinition : IDeepEquatable<DestinyBubbleDefinition>
    {
        /// <summary>
        /// The display properties of this bubble, so you don't have to look them up in a separate list anymore.
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        /// The identifier for the bubble: only guaranteed to be unique within the Destination.
        /// </summary>
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