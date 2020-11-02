using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphConnectionEntry
    {
        public uint SourceNodeHash { get; }
        public uint DestinationNodeHash { get; }

        [JsonConstructor]
        private ActivityGraphConnectionEntry(uint sourceNodeHash, uint destNodeHash)
        {
            SourceNodeHash = sourceNodeHash;
            DestinationNodeHash = destNodeHash;
        }
    }
}
