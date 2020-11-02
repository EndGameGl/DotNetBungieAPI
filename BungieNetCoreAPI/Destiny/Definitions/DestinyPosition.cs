using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions
{
    public class DestinyPosition
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        [JsonConstructor]
        private DestinyPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
