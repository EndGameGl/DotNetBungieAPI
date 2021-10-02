namespace DotNetBungieAPI
{
    /// <summary>
    /// Struct that represents bungie.net resource link
    /// </summary>
    public struct DestinyResource
    {
        /// <summary>
        /// Empty resource link
        /// </summary>
        public static DestinyResource Empty { get; } = new(null);

        /// <summary>
        /// Relative path to resource
        /// </summary>
        public string RelativePath { get; }

        /// <summary>
        /// Absolute path to resource
        /// </summary>
        public string AbsolutePath => $"https://bungie.net{RelativePath}";

        /// <summary>
        /// Whether resource is not empty link
        /// </summary>
        public bool HasValue => !string.IsNullOrEmpty(RelativePath);

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="path"></param>
        public DestinyResource(string path)
        {
            RelativePath = path;
        }

        /// <summary>
        /// Whether one resource equals another
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(DestinyResource a, DestinyResource b)
        {
            return a.RelativePath.Equals(b.RelativePath);
        }

        /// <summary>
        /// Whether one resource is not equal to another
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(DestinyResource a, DestinyResource b)
        {
            return !(a == b);
        }
    }
}