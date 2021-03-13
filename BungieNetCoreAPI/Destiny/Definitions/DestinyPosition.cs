using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions
{
    public class DestinyPosition : IDeepEquatable<DestinyPosition>
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        [JsonConstructor]
        internal DestinyPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool DeepEquals(DestinyPosition other)
        {
            return other != null &&
                X == other.X &&
                Y == other.Y &&
                Z == other.Z;
        }
    }
}
