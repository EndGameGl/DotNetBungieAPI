using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny
{
    public class DestinyColor
    {
        public int Alpha { get; }
        public int Blue { get; }
        public uint ColorHash { get; }
        public int Green { get; }
        public int Red { get; }

        [JsonConstructor]
        private DestinyColor(int alpha, int blue, uint colorHash, int green, int red)
        {
            Alpha = alpha;
            Blue = blue;
            ColorHash = colorHash;
            Green = green;
            Red = red;
        }
    }
}
