using Newtonsoft.Json;

namespace NetBungieApi.Destiny
{
    /// <summary>
    /// Represents a color whose RGBA values are all represented as values between 0 and 255.
    /// </summary>
    public class DestinyColor : IDeepEquatable<DestinyColor>
    {
        public uint ColorHash { get; }
        public int Alpha { get; }
        public int Blue { get; }
        public int Green { get; }
        public int Red { get; }

        [JsonConstructor]
        internal DestinyColor(int alpha, int blue, uint colorHash, int green, int red)
        {
            Alpha = alpha;
            Blue = blue;
            ColorHash = colorHash;
            Green = green;
            Red = red;
        }

        public bool DeepEquals(DestinyColor other)
        {
            return other != null &&
                   ColorHash == other.ColorHash &&
                   Alpha == other.Alpha &&
                   Blue == other.Blue &&
                   Green == other.Green &&
                   Red == other.Red;
        }
    }
}
