using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Destinations
{
    /// <summary>
    /// Basic identifying data about the bubble.
    /// </summary>
    public class DestinationBubbleEntry : IDeepEquatable<DestinationBubbleEntry>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint Hash { get; }

        [JsonConstructor]
        internal DestinationBubbleEntry(DestinyDefinitionDisplayProperties displayProperties, uint hash)
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
