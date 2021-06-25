namespace NetBungieAPI
{
    public struct DestinyResource
    {
        public string RelativePath { get; }
        
        public string AbsolutePath => $"https://bungie.net{RelativePath}";
        
        public bool HasValue => !string.IsNullOrEmpty(RelativePath);

        public DestinyResource(string path)
        {
            RelativePath = path;
        }

        public static bool operator ==(DestinyResource a, DestinyResource b)
        {
            return a.RelativePath.Equals(b.RelativePath);
        }

        public static bool operator !=(DestinyResource a, DestinyResource b)
        {
            return !(a == b);
        }
    }
}