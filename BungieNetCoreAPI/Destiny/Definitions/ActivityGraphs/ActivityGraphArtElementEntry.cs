using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphArtElementEntry
    {
        public DestinyPosition Position { get; }
        [JsonConstructor]
        private ActivityGraphArtElementEntry(DestinyPosition position)
        {
            Position = position;
        }
    }
}
