using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Destinations
{
    /// <summary>
    /// Basic identifying data about the bubble.
    /// </summary>
    public class DestinationBubbleEntry : IDeepEquatable<DestinationBubbleEntry>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public uint Hash { get; init; }

        [JsonConstructor]
        internal DestinationBubbleEntry(DestinyDisplayPropertiesDefinition displayProperties, uint hash)
        {
            DisplayProperties = displayProperties;
            Hash = hash;
        }
        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }

        public bool DeepEquals(DestinationBubbleEntry other)
        {
            return other != null &&
                DisplayProperties.DeepEquals(other.DisplayProperties) &&
                Hash == other.Hash;
        }
    }
}
