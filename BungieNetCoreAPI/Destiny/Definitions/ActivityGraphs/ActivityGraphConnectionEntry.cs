using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// Nodes on a graph can be visually connected: this appears to be the information about which nodes to link. It appears to lack more detailed information, such as the path for that linking.
    /// </summary>
    public class ActivityGraphConnectionEntry : IDeepEquatable<ActivityGraphConnectionEntry>
    {
        public uint SourceNodeHash { get; }
        public uint DestinationNodeHash { get; }

        [JsonConstructor]
        internal ActivityGraphConnectionEntry(uint sourceNodeHash, uint destNodeHash)
        {
            SourceNodeHash = sourceNodeHash;
            DestinationNodeHash = destNodeHash;
        }

        public bool DeepEquals(ActivityGraphConnectionEntry other)
        {
            return other != null &&
                SourceNodeHash == other.SourceNodeHash &&
                DestinationNodeHash == other.DestinationNodeHash;
        }
    }
}
