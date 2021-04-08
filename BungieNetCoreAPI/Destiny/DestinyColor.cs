using Newtonsoft.Json;

namespace NetBungieAPI.Destiny
{
    /// <summary>
    /// Represents a color whose RGBA values are all represented as values between 0 and 255.
    /// </summary>
    public class DestinyColor : IDeepEquatable<DestinyColor>
    {
        public uint ColorHash { get; init; }
        public int Alpha { get; init; }
        public int Blue { get; init; }
        public int Green { get; init; }
        public int Red { get; init; }

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
